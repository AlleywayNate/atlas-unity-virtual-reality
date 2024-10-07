using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WindowSizeSettings : MonoBehaviour
{
    public Slider horizontalScaleSlider;
    public Slider verticalScaleSlider;
    public RectTransform uiWindow; // Reference to the UI window RectTransform

    void Start()
    {
        // Load saved scale or default to 1
        float savedHorizontalScale = PlayerPrefs.GetFloat("UIHorizontalScale", 1.0f);
        float savedVerticalScale = PlayerPrefs.GetFloat("UIVerticalScale", 1.0f);

        horizontalScaleSlider.value = savedHorizontalScale;
        verticalScaleSlider.value = savedVerticalScale;

        // Apply initial scale
        SetHorizontalScale(savedHorizontalScale);
        SetVerticalScale(savedVerticalScale);

        // Add listeners
        horizontalScaleSlider.onValueChanged.AddListener(SetHorizontalScale);
        verticalScaleSlider.onValueChanged.AddListener(SetVerticalScale);
    }

    public void SetHorizontalScale(float scale)
    {
        Vector3 currentScale = uiWindow.localScale;
        currentScale.x = scale;
        uiWindow.localScale = currentScale;

        // Save the setting
        PlayerPrefs.SetFloat("UIHorizontalScale", scale);
    }

    public void SetVerticalScale(float scale)
    {
        Vector3 currentScale = uiWindow.localScale;
        currentScale.y = scale;
        uiWindow.localScale = currentScale;

        // Save the setting
        PlayerPrefs.SetFloat("UIVerticalScale", scale);
    }
}
