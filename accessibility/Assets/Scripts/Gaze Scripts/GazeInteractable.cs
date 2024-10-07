using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GazeInteractable : MonoBehaviour
{
    public float gazeDuration = 2f; // Default gaze time to select
    private float timer = 0f;
    private bool isGazing = false;

    public Image gazeIndicator; // Optional: A UI indicator to show gaze progress

    // Audio Feedback
    private bool hasStartedGazing = false;

    // Haptic Feedback
    private XRNode controllerNode = XRNode.RightHand; // Change if needed

    // Description Audio
    public AudioClip descriptionClip;

    // TTS Manager (optional)
    // private TTSManager ttsManager;

    void Start()
    {
        // Enable TTS only on Windows platform
        // #if UNITY_STANDALONE_WIN
        // ttsManager = FindObjectOfType<TTSManager>();
        // #endif
    }

    void Update()
    {
        if (isGazing)
        {
            timer += Time.deltaTime;
            if (gazeIndicator != null)
            {
                gazeIndicator.fillAmount = timer / gazeDuration; // Update progress indicator
            }

            // Play duration audio once when gazing starts
            if (!hasStartedGazing)
            {
                AudioManager.Instance.PlayStartSelect();
                AudioManager.Instance.PlaySelectDuration(); // Consider making this loop if needed
                TriggerHapticFeedback(0.5f, 0.1f); // Medium amplitude, short duration
                
                // If a description clip is provided, play it
                if (descriptionClip != null)
                {
                    AudioManager.Instance.PlayOneShot(descriptionClip); // Ensure PlayOneShot exists in AudioManager
                }

                // Text-to-Speech fallback (if no audio description)
                // #if UNITY_STANDALONE_WIN
                // if (descriptionClip == null && !string.IsNullOrEmpty(description))
                // {
                //     ttsManager.Speak(description);
                // }
                // #endif

                hasStartedGazing = true;
            }

            if (timer >= gazeDuration)
            {
                // Perform the selection when the gaze completes
                OnGazeComplete();
                ResetGaze();
            }
        }
    }

    public void StartGazing()
    {
        isGazing = true;
        timer = 0f;
        hasStartedGazing = false;
    }

    public void StopGazing()
    {
        isGazing = false;
        ResetGaze();
    }

    private void ResetGaze()
    {
        timer = 0f;
        hasStartedGazing = false;
        if (gazeIndicator != null)
        {
            gazeIndicator.fillAmount = 0f; // Reset progress indicator
        }
    }

    private void OnGazeComplete()
    {
        // Execute the button’s action here
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.Invoke(); // Call the button’s onClick event
            AudioManager.Instance.PlayFinishSelect(); // Ensure PlayFinishSelect exists in AudioManager
            TriggerHapticFeedback(1f, 0.2f); // Strong amplitude, longer duration
        }
    }

    private void TriggerHapticFeedback(float amplitude, float duration)
    {
        // Get the input device for the specified controller node
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);

        if (device.isValid)
        {
            // Send haptic impulse if the controller supports it
            HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    uint channel = 0;
                    device.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
    }

    // Optional: For describing UI elements via text
    // public string description; // Assigned via Inspector
}
