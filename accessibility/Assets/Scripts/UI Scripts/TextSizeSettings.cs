using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TextSizeSettings : MonoBehaviour
{
    public Slider textSizeSlider;
    public RectTransform uiWindow; // Reference to the UI window RectTransform
    private List<Text> uiTexts = new List<Text>();

    void Start()
    {
        // Find all Text components within the UI window
        uiTexts.AddRange(uiWindow.GetComponentsInChildren<Text>(true));

        // Load saved text size or default to 18
        float savedTextSize = PlayerPrefs.GetFloat("UITextSize", 18f);
        textSizeSlider.value = savedTextSize;

        // Apply initial text size
        SetTextSize(savedTextSize);

        // Add listener
        textSizeSlider.onValueChanged.AddListener(SetTextSize);
    }

    public void SetTextSize(float size)
    {
        foreach (Text txt in uiTexts)
        {
            txt.fontSize = Mathf.RoundToInt(size);
        }

        // Save the setting
        PlayerPrefs.SetFloat("UITextSize", size);
    }
}