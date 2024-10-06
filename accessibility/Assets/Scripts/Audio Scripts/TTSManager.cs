#if UNITY_STANDALONE_WIN
using UnityEngine;
using System.Speech.Synthesis;

public class TTSManager : MonoBehaviour
{
    private static TTSManager instance;
    private SpeechSynthesizer synthesizer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            synthesizer = new SpeechSynthesizer();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Speak(string text)
    {
        synthesizer.SpeakAsync(text);
    }

    void OnDestroy()
    {
        if (synthesizer != null)
        {
            synthesizer.Dispose();
        }
    }
}
#endif