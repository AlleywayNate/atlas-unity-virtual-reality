using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSizeSettings : MonoBehaviour
{
    public Slider horizontalScaleSlider;
    public Slider verticalScaleSlider;
    public RectTransform uiWindow; // Reference to the UI window RectTransform

    void Start()
    {
        // Initialize sliders with current scale
        horizontalScaleSlider.value = uiWindow.localScale.x;
        verticalScaleSlider.value = uiWindow.localScale.y;

        // Add listeners
        horizontalScaleSlider.onValueChanged.AddListener(SetHorizontalScale);
        verticalScaleSlider.onValueChanged.AddListener(SetVerticalScale);
    }

    public void SetHorizontalScale(float scale)
    {
        Vector3 currentScale = uiWindow.localScale;
        currentScale.x = scale;
        uiWindow.localScale = currentScale;
    }

    public void SetVerticalScale(float scale)
    {
        Vector3 currentScale = uiWindow.localScale;
        currentScale.y = scale;
        uiWindow.localScale = currentScale;
    }
}
