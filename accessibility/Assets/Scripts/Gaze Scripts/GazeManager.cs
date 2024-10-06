using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    public Camera vrCamera; // Main camera used for VR
    public float maxDistance = 10f; // Max distance for gaze interaction
    private GameObject currentGazedObject;

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
        }
    }
}