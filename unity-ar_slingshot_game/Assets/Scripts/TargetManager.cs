using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject targetPrefab; // Prefab for the target
    public int targetCount = 5; // Number of targets to spawn
    public UIManager uiManager; // Reference to the UI Manager

    private List<GameObject> activeTargets = new List<GameObject>(); // List of active targets

    public void SpawnTargets(Vector3 planeCenter, Quaternion planeRotation)
    {
        ClearTargets(); // Clear existing targets

        for (int i = 0; i < targetCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(planeCenter.x - 1.0f, planeCenter.x + 1.0f), // Random x
                planeCenter.y, // Use the plane's height
                Random.Range(planeCenter.z - 1.0f, planeCenter.z + 1.0f) // Random z
            );

            GameObject target = Instantiate(targetPrefab, spawnPosition, planeRotation);
            activeTargets.Add(target); // Add to active targets list
            target.GetComponent<Target>().OnTargetHit += HandleTargetHit; // Subscribe to the hit event
        }
    }

    public void ClearTargets()
    {
        foreach (GameObject target in activeTargets)
        {
            Destroy(target); // Destroy each target
        }
        activeTargets.Clear(); // Clear the list
    }

    private void HandleTargetHit(GameObject target)
    {
        activeTargets.Remove(target); // Remove from active targets
        Destroy(target); // Destroy the target

        uiManager.UpdateScore(10); // Update score with a specific point value
    }
}
