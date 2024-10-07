using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class GestureReactionManager : MonoBehaviour
{
    public Image waveImage;
    public Image facePalmImage;
    public Image xArmsImage;

    void Start()
    {
        // Hide all images initially
        HideAllImages();
    }

    public void ShowWaveReaction()
    {
        HideAllImages();
        waveImage.gameObject.SetActive(true);
    }

    public void ShowFacePalmReaction()
    {
        HideAllImages();
        facePalmImage.gameObject.SetActive(true);
    }

    public void ShowXArmsReaction()
    {
        HideAllImages();
        xArmsImage.gameObject.SetActive(true);
    }

    private void HideAllImages()
    {
        waveImage.gameObject.SetActive(false);
        facePalmImage.gameObject.SetActive(false);
        xArmsImage.gameObject.SetActive(false);
    }
}