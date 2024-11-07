using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject gameUI;
    public GameObject playAgainButton;
    public GameObject leaderBoardButton;
    public GameObject leaderBoardUI;
    public Text scoreTxt;
    public GameObject ammoImageGrid;

    private int totalPoints = 0;

    public void InitializeUI(int ammo)
    {
        totalPoints = 0;
        scoreTxt.text = totalPoints.ToString();
        startButton.SetActive(true);
        gameUI.SetActive(false);

        for (int i = 0; i < ammo; i++)
        {
            GameObject ammoGO = Instantiate(/* Your ammo image prefab */);
            ammoGO.transform.SetParent(ammoImageGrid.transform, false);
        }
    }

    public void UpdateScore(int points)
    {
        totalPoints += points;
        scoreTxt.text = totalPoints.ToString();
    }

    public void ShowPlayAgainButton()
    {
        playAgainButton.SetActive(true);
        leaderBoardButton.SetActive(true);
    }

    public void ShowLeaderBoard()
    {
        leaderBoardUI.SetActive(true);
    }

    public void ClearAmmoUI()
    {
        foreach (Transform child in ammoImageGrid.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void OnStartButtonClicked()
    {
        // Logic to start the game
    }

    public void OnPlayAgainButtonClicked()
    {
        // Logic to restart the game
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
