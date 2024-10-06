using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighContrastSettings : MonoBehaviour
{
    public Toggle highContrastToggle;
    public List<Image> uiImages; // UI Images to change color (e.g., backgrounds, buttons)
    public List<Text> uiTexts; // UI Texts to change color
    public Color normalBackgroundColor = Color.white;
    public Color highContrastBackgroundColor = Color.black;
    public Color normalTextColor = Color.black;
    public Color highContrastTextColor = Color.white;
    public Color normalButtonColor = Color.gray;
    public Color highContrastButtonColor = Color.yellow;

    void Start()
    {
        // Initialize toggle based on saved settings
        highContrastToggle.isOn = PlayerPrefs.GetInt("HighContrast", 0) == 1;

        // Add listener
        highContrastToggle.onValueChanged.AddListener(SetHighContrast);

        // Apply initial state
        SetHighContrast(highContrastToggle.isOn);
    }

    public void SetHighContrast(bool isEnabled)
    {
        foreach (Image img in uiImages)
        {
            // Example: Assume the first image is background
            if (img.name.Contains("Background"))
            {
                img.color = isEnabled ? highContrastBackgroundColor : normalBackgroundColor;
            }
            else
            {
                img.color = isEnabled ? highContrastButtonColor : normalButtonColor;
            }
        }

        foreach (Text txt in uiTexts)
        {
            txt.color = isEnabled ? highContrastTextColor : normalTextColor;
        }

        // Save the setting
        PlayerPrefs.SetInt("HighContrast", isEnabled ? 1 : 0);
    }
}