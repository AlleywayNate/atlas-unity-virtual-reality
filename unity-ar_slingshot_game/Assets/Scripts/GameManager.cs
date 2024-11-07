using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public UnityEvent onGameStart; // Event when the game starts
    public UnityEvent onGameEnd; // Event when the game ends

    private int totalPoints; // Total points accumulated
    private bool isGameActive; // Tracks if the game is currently active

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set the singleton instance
            DontDestroyOnLoad(gameObject); // Keep this instance across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }

    public void StartGame()
    {
        isGameActive = true; // Set game state to active
        totalPoints = 0; // Reset points
        onGameStart.Invoke(); // Trigger start event
        // Additional logic to initialize game elements
    }

    public void EndGame()
    {
        isGameActive = false; // Set game state to inactive
        onGameEnd.Invoke(); // Trigger end event
        // Logic to handle end of game (show scores, reset UI, etc.)
    }

    public void UpdateScore(int points)
    {
        totalPoints += points; // Update total points
        // Update score UI or other necessary components
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        StartGame(); // Optionally restart the game
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }

    void OnEnable()
    {
        // Subscribe to plane selection event
        PlaneSelector.OnPlaneSelected.AddListener(HandlePlaneSelected);
    }

    void OnDisable()
    {
        // Unsubscribe from events
        PlaneSelector.OnPlaneSelected.RemoveListener(HandlePlaneSelected);
    }

    private void HandlePlaneSelected(ARPlane selectedPlane)
    {
        // Logic to handle what happens when a plane is selected, like starting the game
        StartGame(); // Start the game when a plane is selected
    }
}
