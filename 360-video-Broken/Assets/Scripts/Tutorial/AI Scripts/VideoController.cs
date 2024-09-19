using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playButton;
    public Button pauseButton;
    public Button rewindButton;
    public Button fastForwardButton;
    public Button loopButton;
    public Button skipButton;
    public Slider playbackSpeedSlider;
    public Slider volumeSlider;

    private bool isLooping = false;
    private double skipAmount = 10.0; // Time to skip forward/backward in seconds

    void Start()
    {
        // Button listeners
        playButton.onClick.AddListener(PlayVideo);
        pauseButton.onClick.AddListener(PauseVideo);
        rewindButton.onClick.AddListener(RewindVideo);
        fastForwardButton.onClick.AddListener(FastForwardVideo);
        loopButton.onClick.AddListener(ToggleLoop);
        skipButton.onClick.AddListener(SkipVideo);
        playbackSpeedSlider.onValueChanged.AddListener(ChangePlaybackSpeed);
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        videoPlayer.loopPointReached += OnVideoEnded; // Handle loop and end of video
    }

    void PlayVideo()
    {
        videoPlayer.Play();
    }

    void PauseVideo()
    {
        videoPlayer.Pause();
    }

    void RewindVideo()
    {
        if (videoPlayer.time >= skipAmount)
        {
            videoPlayer.time -= skipAmount;
        }
        else
        {
            videoPlayer.time = 0; // Can't go below 0
        }
    }

    void FastForwardVideo()
    {
        if (videoPlayer.time + skipAmount < videoPlayer.length)
        {
            videoPlayer.time += skipAmount;
        }
        else
        {
            videoPlayer.time = videoPlayer.length; // Go to the end of the video
        }
    }

    void ToggleLoop()
    {
        isLooping = !isLooping;
        videoPlayer.isLooping = isLooping;
    }

    void SkipVideo()
    {
        // Skip to a specific time, e.g., jump 20 seconds forward
        if (videoPlayer.time + 20.0 < videoPlayer.length)
        {
            videoPlayer.time += 20.0;
        }
    }

    void ChangePlaybackSpeed(float speed)
    {
        videoPlayer.playbackSpeed = speed;
    }

    void ChangeVolume(float volume)
    {
        videoPlayer.SetDirectAudioVolume(0, volume); // Assuming 0 is the audio track
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        if (!isLooping)
        {
            // Optional: Handle any behavior when the video ends, like returning to a menu
        }
    }
}