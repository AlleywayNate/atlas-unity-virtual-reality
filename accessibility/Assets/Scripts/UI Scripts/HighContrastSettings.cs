using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighContrastSettings : MonoBehaviour
{
    public Toggle highContrastToggle;
    public RectTransform uiWindow; // Reference to the UI window RectTransform
    public Color normalBackgroundColor = Color.white;
    public Color highContrastBackgroundColor = Color.black;
    public Color normalTextColor = Color.black;
    public Color highContrastTextColor = Color.white;
    public Color normalButtonColor = Color.gray;
    public Color highContrastButtonColor = Color.yellow;

    private List<Image> uiImages = new List<Image>();
    private List<Text> uiTexts = new List<Text>();

    void Start()
    {
        // Find all Image and Text components within the UI window
        uiImages.AddRange(uiWindow.GetComponentsInChildren<Image>(true));
        uiTexts.AddRange(uiWindow.GetComponentsInChildren<Text>(true));

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
            // Simple example: Assume buttons have a specific tag or name
            if (img.name.ToLower().Contains("background"))
            {
                img.color = isEnabled ? highContrastBackgroundColor : normalBackgroundColor;
            }
            else if (img.GetComponent<Button>() != null)
            {
                img.color = isEnabled ? highContrastButtonColor : normalButtonColor;
            }
            else
            {
                // Other images can have default or specific high contrast colors
                img.color = isEnabled ? highContrastBackgroundColor : normalBackgroundColor;
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