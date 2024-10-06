using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSettings : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the volume slider
    public GazeManager gazeManager; // Reference to GazeManager
    public Toggle gazeHintsToggle; // Reference to the gaze hints checkbox

    void Start()
    {
        // Initialize slider with current volume
        volumeSlider.value = AudioListener.volume;

        // Add listeners
        volumeSlider.onValueChanged.AddListener(SetVolume);
        gazeHintsToggle.onValueChanged.AddListener(ToggleGazeHints);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ToggleGazeHints(bool isEnabled)
    {
        gazeManager.ToggleGazeHints(isEnabled);
    }
}