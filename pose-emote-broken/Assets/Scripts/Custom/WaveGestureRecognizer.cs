using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGestureRecognizer : MonoBehaviour
{
    public Transform handTransform; // Assign hand transform in the inspector
    private Vector3 previousPosition;
    private float waveThreshold = 0.1f; // Adjust threshold based on the scale of your world
    private int waveCount = 0;
    private float waveTimeLimit = 0.5f; // Time limit for a complete wave cycle
    private float waveTimer = 0.0f;

    private void Start()
    {
        previousPosition = handTransform.position;
    }

    private void Update()
    {
        Vector3 currentPosition = handTransform.position;
        float deltaX = currentPosition.x - previousPosition.x;

        // Check if the hand moved enough on the X-axis (side-to-side)
        if (Mathf.Abs(deltaX) > waveThreshold)
        {
            waveCount++;
            previousPosition = currentPosition;
            waveTimer = 0.0f; // Reset timer after a valid wave move
        }

        waveTimer += Time.deltaTime;

        // If the timer exceeds the limit, reset wave count
        if (waveTimer > waveTimeLimit)
        {
            waveCount = 0;
            waveTimer = 0.0f;
        }

        // Recognize a wave gesture after enough back-and-forth movements
        if (waveCount >= 4) // Adjust this value depending on the number of back-and-forth movements you want
        {
            Debug.Log("Wave Gesture Recognized!");
            waveCount = 0; // Reset after a successful recognition
        }
    }
}