using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ColorBlindnessSettings : MonoBehaviour
{
    public Dropdown colorBlindnessDropdown;
    public List<Image> uiImages; // UI Images to change color (e.g., backgrounds, buttons)
    public List<Text> uiTexts; // UI Texts to change color
    public RectTransform uiWindow; // Reference to the UI window

    // Define color palettes
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

    void Start()
    {
        // Populate dropdown options if not set
        if (colorBlindnessDropdown.options.Count == 0)
        {
            colorBlindnessDropdown.options.Clear();
            foreach (ColorPalette palette in colorPalettes)
            {
                colorBlindnessDropdown.options.Add(new Dropdown.OptionData() { text = palette.modeName });
            }
        }

        // Initialize dropdown based on saved settings
        string savedMode = PlayerPrefs.GetString("ColorBlindnessMode", "Default");
        colorBlindnessDropdown.value = colorPalettes.FindIndex(p => p.modeName == savedMode);
        if (colorBlindnessDropdown.value == -1) colorBlindnessDropdown.value = 0; // Default to first option

        // Add listener
        colorBlindnessDropdown.onValueChanged.AddListener(SetColorBlindnessMode);

        // Apply initial mode
        SetColorBlindnessMode(colorBlindnessDropdown.value);
    }

    public void SetColorBlindnessMode(int index)
    {
        if (index < 0 || index >= colorPalettes.Count)
            index = 0; // Default

        ColorPalette selectedPalette = colorPalettes[index];

        foreach (Image img in uiImages)
        {
            // Example: Assume the first image is background
            if (img.name.ToLower().Contains("background"))
            {
                img.color = selectedPalette.backgroundColor;
            }
            else if (img.GetComponent<Button>() != null)
            {
                // Assign different button colors based on index or order
                // Example: Alternate button colors
                Button btn = img.GetComponent<Button>();
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
                img.color = selectedPalette.backgroundColor; // Default to background color
            }
        }

        foreach (Text txt in uiTexts)
        {
            txt.color = selectedPalette.textColor;
        }

        // Save the setting
        PlayerPrefs.SetString("ColorBlindnessMode", selectedPalette.modeName);
    }
}