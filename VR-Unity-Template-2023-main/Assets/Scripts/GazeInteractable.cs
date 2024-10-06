using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeInteractable : MonoBehaviour
{
    public float gazeDuration = 2f; // Default gaze time to select
    private float timer = 0f;
    private bool isGazing = false;

    public Image gazeIndicator; // Optional: A UI indicator to show gaze progress

    void Update()
    {
        if (isGazing)
        {
            timer += Time.deltaTime;
            gazeIndicator.fillAmount = timer / gazeDuration; // Update progress indicator

            if (timer >= gazeDuration)
            {
                // Perform the selection
                OnGazeComplete();
                ResetGaze();
            }
        }
    }

    public void StartGazing()
    {
        isGazing = true;
        timer = 0f;
    }

    public void StopGazing()
    {
        isGazing = false;
        ResetGaze();
    }

    private void ResetGaze()
    {
        timer = 0f;
        gazeIndicator.fillAmount = 0f; // Reset progress indicator
    }

    private void OnGazeComplete()
    {
        // Execute the button’s action here
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.Invoke(); // Call the button’s onClick event
        }
    }
}
