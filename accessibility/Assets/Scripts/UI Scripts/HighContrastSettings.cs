using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighContrastSettings : MonoBehaviour
{
    public Toggle highContrastToggle;
    public RectTransform uiWindow; // Reference to the UI window RectTransform

    [System.Serializable]
    public struct ColorPalette
    {
        public string modeName;
        public Color backgroundColor;
        public Color textColor;
        public Color buttonColor1;
        public Color buttonColor2;
        public Color buttonColor3;
        public Color borderColor;
    }

    public List<ColorPalette> colorPalettes;

    private List<Image> uiImages = new List<Image>();
    private List<Text> uiTexts = new List<Text>();

    void Start()
    {
        // Find all Image and Text components within the UI window
        uiImages.AddRange(uiWindow.GetComponentsInChildren<Image>(true));
        uiTexts.AddRange(uiWindow.GetComponentsInChildren<Text>(true));

        // Populate dropdown options if not set (already handled in previous steps)

        // Load saved high contrast setting or default to off
        bool savedHighContrast = PlayerPrefs.GetInt("HighContrast", 0) == 1;
        highContrastToggle.isOn = savedHighContrast;

        // Add listener
        highContrastToggle.onValueChanged.AddListener(SetHighContrast);

        // Apply initial state
        SetHighContrast(savedHighContrast);
    }

    public void SetHighContrast(bool isEnabled)
    {
        // Assume 'Default' is at index 0
        ColorPalette selectedPalette = colorPalettes[0];
        if (isEnabled && colorPalettes.Count > 1)
        {
            selectedPalette = colorPalettes[1]; // High Contrast Palette
        }

        foreach (Image img in uiImages)
        {
            if (img.name.ToLower().Contains("background"))
            {
                img.color = selectedPalette.backgroundColor;
            }
            else if (img.GetComponent<Button>() != null)
            {
                // Assign button colors in a cyclical manner
                int btnIndex = uiImages.IndexOf(img);
                switch (btnIndex % 3)
                {
                    case 0:
                        img.color = selectedPalette.buttonColor1;
                        break;
                    case 1:
                        img.color = selectedPalette.buttonColor2;
                        break;
                    case 2:
                        img.color = selectedPalette.buttonColor3;
                        break;
                }
            }
            else
            {
                img.color = selectedPalette.backgroundColor; // Default
            }
        }

        foreach (Text txt in uiTexts)
        {
            txt.color = selectedPalette.textColor;
        }

        // Save the setting
        PlayerPrefs.SetInt("HighContrast", isEnabled ? 1 : 0);
    }
}
