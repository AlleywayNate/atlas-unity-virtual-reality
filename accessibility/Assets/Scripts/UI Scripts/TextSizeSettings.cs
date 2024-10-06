using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSizeSettings : MonoBehaviour
{
    public Slider textSizeSlider;
    public List<Text> uiTexts; // List of all Text components to scale

    // Alternatively, if using TextMeshPro
    // public List<TMPro.TextMeshProUGUI> uiTexts;

    void Start()
    {
        // Initialize slider with current text size
        if (uiTexts.Count > 0)
        {
            textSizeSlider.value = uiTexts[0].fontSize;
        }

        // Add listener
        textSizeSlider.onValueChanged.AddListener(SetTextSize);
    }

    public void SetTextSize(float size)
    {
        foreach (Text txt in uiTexts)
        {
            txt.fontSize = Mathf.RoundToInt(size);
        }

        // If using TextMeshPro:
        // foreach (var txt in uiTexts)
        // {
        //     txt.fontSize = size;
        // }
    }
}
