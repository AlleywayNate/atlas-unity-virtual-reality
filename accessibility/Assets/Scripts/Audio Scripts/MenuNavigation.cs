using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsPanel;
    public GameObject optionsPanel;

    // Call this when Settings button is clicked
    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsPanel.SetActive(true);
    }

    // Call this when Back button in Settings is clicked
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Similarly, add methods for Options panel if needed
}
