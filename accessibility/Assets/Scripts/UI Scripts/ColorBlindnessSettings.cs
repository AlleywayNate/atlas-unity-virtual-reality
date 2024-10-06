using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ColorBlindnessSettings : MonoBehaviour
{
    public Dropdown colorBlindnessDropdown;
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

        // Populate dropdown options if not set
        if (colorBlindnessDropdown.options.Count == 0)
        {
            colorBlindnessDropdown.options.Clear();
            foreach (ColorPalette palette in colorPalettes)
            {
                colorBlindnessDropdown.options.Add(new Dropdown.OptionData() { text = palette.modeName });
            }
        }

        // Load saved color blindness mode or default to 'Default'
        string savedMode = PlayerPrefs.GetString("ColorBlindnessMode", "Default");
        int savedIndex = colorPalettes.FindIndex(p => p.modeName == savedMode);
        colorBlindnessDropdown.value = savedIndex != -1 ? savedIndex : 0;

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
        PlayerPrefs.SetString("ColorBlindnessMode", selectedPalette.modeName);
    }
}