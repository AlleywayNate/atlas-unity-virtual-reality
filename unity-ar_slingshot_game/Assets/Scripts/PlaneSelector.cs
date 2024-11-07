using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Events;

public class PlaneSelector : MonoBehaviour
{
    private ARPlaneManager planeManager; // Reference to ARPlaneManager
    public UnityEvent<ARPlane> OnPlaneSelected; // Event triggered when a plane is selected
    private ARPlane selectedPlane; // Current selected plane

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>(); // Get ARPlaneManager component
        OnPlaneSelected = new UnityEvent<ARPlane>(); // Initialize event
    }

    void OnEnable()
    {
        planeManager.planesChanged += PlanesChanged;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= PlanesChanged;
    }

    private void PlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            // Handle newly detected planes
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                SelectPlaneAtTouch(touch.position);
            }
        }
    }

    private void SelectPlaneAtTouch(Vector2 touchPosition)
    {
        if (planeManager.trackables.count > 0)
        {
            ARRaycastManager raycastManager = FindObjectOfType<ARRaycastManager>();
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (raycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                selectedPlane = hits[0].trackableId;

                if (selectedPlane != null)
                {
                    OnPlaneSelected.Invoke(selectedPlane); // Invoke the selection event
                    HighlightSelectedPlane(); // Optional visual feedback
                }
            }
        }
    }

    private void HighlightSelectedPlane()
    {
        if (selectedPlane != null)
        {
            Material material = selectedPlane.GetComponent<Renderer>().material;
            material.color = Color.green; // Change the color of the selected plane
        }
    }

    private void StartGame(ARPlane plane)
    {
        // Logic to start the game, e.g., spawn targets
        targetManager.SpawnTargets(plane.center, plane.transform.rotation);
    }
}
