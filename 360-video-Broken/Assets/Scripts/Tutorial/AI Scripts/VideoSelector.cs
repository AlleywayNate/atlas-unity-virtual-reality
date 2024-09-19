using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoSelector : MonoBehaviour
{
    public GameObject buttonPrefab;          // Reference to the video button prefab
    public Transform contentPanel;           // Reference to the content panel of the ScrollView
    public VideoPlayer videoPlayer;          // Reference to the VideoPlayer component
    public VideoClip[] videoClips;            // Array of video clips to select from

    private void Start()
    {
        PopulateScrollView();
    }

    private void PopulateScrollView()
    {
        foreach (VideoClip videoClip in videoClips)
        {
            GameObject buttonObject = Instantiate(buttonPrefab, contentPanel);
            Button button = buttonObject.GetComponent<Button>();
            Text buttonText = buttonObject.GetComponentInChildren<Text>();

            // Set the button text to the name of the video clip
            buttonText.text = videoClip.name;

            // Add a listener to the button to play the video
            button.onClick.AddListener(() => PlayVideo(videoClip));
        }
    }

    private void PlayVideo(VideoClip videoClip)
    {
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }
}
