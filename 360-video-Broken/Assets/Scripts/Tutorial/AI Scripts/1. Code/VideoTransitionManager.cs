using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTransitionManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float transitionDuration = 1.0f;

    private VideoClip currentVideo;
    private VideoClip nextVideo;

    public void PlayNextVideo(VideoClip nextVideo)
    {
        this.nextVideo = nextVideo;
        videoPlayer.clip = nextVideo;
        videoPlayer.Play();

        // Start cross-fading
        StartCoroutine(CrossFade());
    }

    private IEnumerator CrossFade()
    {
        float timer = 0;
        while (timer < transitionDuration)
        {
            float t = timer / transitionDuration;
            videoPlayer.SetDirectAudioVolume(0, 1 - t);
            timer += Time.deltaTime;
            yield return null;
        }
        videoPlayer.SetDirectAudioVolume(0, 0);
    }
}
