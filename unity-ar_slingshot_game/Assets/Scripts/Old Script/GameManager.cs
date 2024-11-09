using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Targets")]
    public GameObject targetPrefab;
    public int targetCount = 5;
    public int maxAmmo = 7;

    [Header("UI Elements")]
    public GameObject planeSearchingUI;
    public GameObject planeSelectionUI;
    public GameObject startButton;
    public GameObject gameUI;
    public Text scoreText;
    public GameObject ammoImagePrefab;
    public GameObject ammoContainer;
    public GameObject playAgainButton;
    public GameObject leaderboardButton;
    public GameObject leaderboardUI;

    [Header("Audio")]
    public AudioSource endGameSound;
    public AudioSource planeSelectedSound;

    [Header("Other References")]
    public Leaderboard leaderboard;
    public Material planeOcclusionMaterial;

    private int score = 0;
    private ARPlane selectedPlane = null;    
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private SlingShot slingShot;
    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private Dictionary<int, GameObject> activeTargets = new Dictionary<int, GameObject>();

    public event System.Action<ARPlane> PlaneSelected;

    private void Awake()
    {
        FindObjectOfType<ARSession>().Reset();
    }

    private void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        planeManager = FindObjectOfType<ARPlaneManager>();
        slingShot = FindObjectOfType<SlingShot>();

        planeManager.planesChanged += UpdatePlaneUIOnDetection;
        PlaneSelected += SetupTargetsOnPlaneSelection;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && selectedPlane == null && planeManager.trackables.count > 0)
        {
            HandlePlaneSelection();
        }
    }

    private void HandlePlaneSelection()
    {
        Touch touch = Input.GetTouch(0);
        
        if (touch.phase == TouchPhase.Began && raycastManager.Raycast(touch.position, raycastHits, TrackableType.PlaneWithinPolygon))
        {
            ARRaycastHit hit = raycastHits[0];
            selectedPlane = planeManager.GetPlane(hit.trackableId);
            PrepareSelectedPlane(selectedPlane);
            PlaneSelected?.Invoke(selectedPlane);
        }
    }

    private void PrepareSelectedPlane(ARPlane plane)
    {
        plane.GetComponent<Renderer>().material = planeOcclusionMaterial;
        HideOtherPlanes(plane);
        planeSelectionUI.SetActive(false);
        planeSelectedSound.Play();
    }

    private void HideOtherPlanes(ARPlane selected)
    {
        foreach (ARPlane plane in planeManager.trackables)
        {
            if (plane != selected)
                plane.gameObject.SetActive(false);
        }
        planeManager.enabled = false;
    }

    private void UpdatePlaneUIOnDetection(ARPlanesChangedEventArgs args)
    {
        if (selectedPlane == null && planeManager.trackables.count > 0)
        {
            planeSearchingUI.SetActive(false);
            planeSelectionUI.SetActive(true);
            planeManager.planesChanged -= UpdatePlaneUIOnDetection;
        }
    }

    private void SetupTargetsOnPlaneSelection(ARPlane plane)
    {
        ClearExistingTargets();
        ShowStartButton();

        for (int i = 1; i <= targetCount; i++)
        {
            GameObject target = Instantiate(targetPrefab, plane.center, plane.transform.rotation, plane.transform);
            SetupTarget(target, i, plane);
            activeTargets.Add(i, target);
        }
    }

    private void SetupTarget(GameObject target, int id, ARPlane plane)
    {
        target.GetComponent<MoveRandomly>().StartMoving(plane);
        var targetComponent = target.GetComponent<Target>();
        targetComponent.ID = id;
        targetComponent.OnTargetDestroy += HandleTargetHit;
    }

    private void HandleTargetHit(int id, int points)
    {
        activeTargets.Remove(id);
        UpdateScore(points);
        if (activeTargets.Count == 0)
        {
            EndGame();
        }
    }

    private void UpdateScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void StartGame()
    {
        InitializeGameUI();
        ResetAmmo();
    }

    private void InitializeGameUI()
    {
        score = 0;
        scoreText.text = score.ToString();
        startButton.SetActive(false);
        gameUI.SetActive(true);
    }

    private void ResetAmmo()
    {
        slingShot.AmmoLeft = maxAmmo;
        slingShot.OnReload += ReloadAmmoUI;
        slingShot.Reload();

        for (int i = 0; i < maxAmmo; i++)
        {
            GameObject ammoImage = Instantiate(ammoImagePrefab, ammoContainer.transform);
        }
    }

    private void ReloadAmmoUI(int ammoLeft)
    {
        if (ammoContainer.transform.childCount > 0 && ammoLeft >= 0)
        {
            Destroy(ammoContainer.transform.GetChild(0).gameObject);
        }
        else if (ammoLeft == 0)
        {
            EndGame();
            DisplayLeaderboard();
        }
    }

    private void EndGame()
    {
        endGameSound.Play();
        leaderboard.SetLeader(score);
        ClearAmmoUI();
        slingShot.Clear();
        slingShot.OnReload -= ReloadAmmoUI;
        playAgainButton.SetActive(true);
        leaderboardButton.SetActive(true);
    }

    private void ClearAmmoUI()
    {
        foreach (Transform ammo in ammoContainer.transform)
        {
            Destroy(ammo.gameObject);
        }
    }

    public void PlayAgain()
    {
        leaderboardButton.SetActive(false);
        SetupTargetsOnPlaneSelection(selectedPlane);
        endGameSound.Stop();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("ARSlingshotGame");
    }

    private void ClearExistingTargets()
    {
        foreach (var target in activeTargets.Values)
        {
            Destroy(target);
        }
        activeTargets.Clear();
    }

    private void ShowStartButton()
    {
        startButton.SetActive(true);
    }

    public void DisplayLeaderboard()
    {
        leaderboard.PrintLeaderBoard();
        leaderboardUI.SetActive(true);
    }
}
