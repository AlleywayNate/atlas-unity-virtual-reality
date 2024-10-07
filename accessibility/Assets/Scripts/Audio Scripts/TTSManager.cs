using UnityEngine;
using UnityEngine.Networking; // Import the Networking namespace
using System.Collections;
using System.IO;

public class TTSManager : MonoBehaviour
{
    public static TTSManager Instance { get; private set; }

    // URL for the TTS API (You can replace this with your actual TTS service URL)
    private const string ttsApiUrl = "https://your-tts-api-url";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Speak(string text)
    {
        StartCoroutine(SpeakCoroutine(text));
    }

    private IEnumerator SpeakCoroutine(string text)
    {
        // Make a request to the TTS API
        using (UnityWebRequest www = UnityWebRequest.Get(ttsApiUrl + "?text=" + UnityWebRequest.EscapeURL(text)))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)

            {
                Debug.LogError("TTS Error: " + www.error);
                yield break;
            }

            // Convert the received byte array (WAV data) to AudioClip
            AudioClip clip = WavUtility.ToAudioClip(www.downloadHandler.data, 0, "TTSClip", 1);
            if (clip != null)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = clip;
                audioSource.Play();
            }
            else
            {
                Debug.LogError("Failed to create AudioClip from WAV data.");
            }
        }
    }
}

public static class WavUtility
{
    public static AudioClip ToAudioClip(byte[] wavData, int offsetSamples, string name, int channels)
    {
        // Read the header
        using (MemoryStream stream = new MemoryStream(wavData))
        using (BinaryReader reader = new BinaryReader(stream))
        {
            // Read header
            string riff = new string(reader.ReadChars(4));
            int chunkSize = reader.ReadInt32();
            string wave = new string(reader.ReadChars(4));
            string fmt = new string(reader.ReadChars(4));
            int fmtSize = reader.ReadInt32();
            int audioFormat = reader.ReadInt16();
            channels = reader.ReadInt16();
            int sampleRate = reader.ReadInt32();
            int byteRate = reader.ReadInt32();
            int blockAlign = reader.ReadInt16();
            int bitsPerSample = reader.ReadInt16();
            string data = new string(reader.ReadChars(4));
            int dataSize = reader.ReadInt32();

            // Convert data to float array
            float[] audioData = new float[dataSize / sizeof(short)];
            for (int i = 0; i < audioData.Length; i++)
            {
                audioData[i] = reader.ReadInt16() / 32768.0f; // Convert to [-1, 1] range
            }

            // Create the AudioClip
            AudioClip audioClip = AudioClip.Create(name, audioData.Length, channels, sampleRate, false);
            audioClip.SetData(audioData, 0);
            return audioClip;
        }
    }
}
