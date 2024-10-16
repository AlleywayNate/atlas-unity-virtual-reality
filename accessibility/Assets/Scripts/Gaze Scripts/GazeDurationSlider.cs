using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeDurationSlider : MonoBehaviour
{
    public Slider gazeSlider; // Reference to the UI Slider
    public GazeInteractable[] gazeInteractables; // All interactable elements

    void Start()
    {
        // Set default value for the slider based on a pre-defined gaze duration
        gazeSlider.value = gazeInteractables[0].gazeDuration;
        
        // Add a listener to update gaze duration dynamically
        gazeSlider.onValueChanged.AddListener(delegate { UpdateGazeDuration(); });
    }

    void UpdateGazeDuration()
    {
        foreach (GazeInteractable interactable in gazeInteractables)
        {
            interactable.gazeDuration = gazeSlider.value; // Update duration
        }
    }
}