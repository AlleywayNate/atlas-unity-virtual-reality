using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    public Camera vrCamera; // Main camera used for VR
    public float maxDistance = 10f; // Max distance for gaze interaction
    public float gazeHintInterval = 5f; // Time between gaze hints
    private float hintTimer = 0f;

    private GameObject currentGazedObject;
    private bool showGazeHints = true; // Controlled via settings

    void Update()
    {
        Ray ray = new Ray(vrCamera.transform.position, vrCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.transform.gameObject != currentGazedObject)
            {
                // Stopped looking at the previous object
                if (currentGazedObject != null)
                {
                    GazeInteractable gazeInteractable = currentGazedObject.GetComponent<GazeInteractable>();
                    if (gazeInteractable != null)
                    {
                        gazeInteractable.StopGazing();
                    }
                }

                // Start gazing at the new object
                currentGazedObject = hit.transform.gameObject;
                GazeInteractable newGazeInteractable = currentGazedObject.GetComponent<GazeInteractable>();
                if (newGazeInteractable != null)
                {
                    newGazeInteractable.StartGazing();
                }

                // Reset hint timer
                hintTimer = 0f;
            }
            else
            {
                // Continue gazing at the current object
                if (currentGazedObject != null && showGazeHints)
                {
                    hintTimer += Time.deltaTime;
                    if (hintTimer >= gazeHintInterval)
                    {
                        AudioManager.Instance.PlayGazeHint();
                        hintTimer = 0f;
                    }
                }
            }
        }
        else if (currentGazedObject != null)
        {
            // Stop gazing if no longer looking at any object
            GazeInteractable gazeInteractable = currentGazedObject.GetComponent<GazeInteractable>();
            if (gazeInteractable != null)
            {
                gazeInteractable.StopGazing();
            }
            currentGazedObject = null;
            hintTimer = 0f;
        }
    }

    // Method to toggle gaze hints from settings
    public void ToggleGazeHints(bool isEnabled)
    {
        showGazeHints = isEnabled;
    }
}
