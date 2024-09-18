using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager360 : MonoBehaviour
{
    public GameObject[] objectsToHide;
    public FadeCanvas fadeCanvas;
    public Material videoMaterial;
    public VideoPlayer videoPlayer;
    public float fadeDuration = 1.0f;

    private Material _skyMaterial;

    public void Start()
    {
        _skyMaterial = RenderSettings.skybox;
    }

    public void StartVideo()
    {
        StartCourtine(FadeAndSwitchVideo(_skyMaterial, videoPlayer.Play));
    }

    public void PauseVideo()
    {
        StartCourtine(FadeAndSwitchVideo(_skyMaterial, videoPlayer.Pause));
    }

    private IEnumerator FadeAndSwitchVideo(Material targetMaterial, Action onCompleteAction)
    {
        fadeCanvas.QuickFadeIn();
        yield return new WaitForSeconds(fadeDuration);

        SetObjectsActive(targetMaterial.Equals(_skyMaterial));
        fadeCanvas.QuickFadeOut();

        RenderSettings.skybox = targetMaterial;
        onCompleteAction.Invoke();

    }

    private void SetObjectsActive(bool isActive)
    {
        foreach(GameObject ogj in objectsToHide)
        {
            object.SetActive(isActive);
        }
    }

}
