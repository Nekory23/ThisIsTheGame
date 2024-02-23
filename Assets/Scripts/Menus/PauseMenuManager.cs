using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject mainPauseScreen;
    [SerializeField] private GameObject howToPlayScreen;

    [Header("Player")]
    [SerializeField] private PlayerData playerData;

    private void Awake() 
    {
        playerData = new PlayerData();
        playerData.LoadPlayerData();    
    }

    // OPEN PAUSE MENU
    public void OpenPauseMenu()
    {
        Debug.Log("Open Pause Menu");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePauseMenu()
    {
        Debug.Log("Close Pause Menu");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // PAUSE MENU BUTTONS
    public void Continue()
    {
        Debug.Log("Continue");
        ClosePauseMenu();
    }
    
    public void SaveGame()
    {
        Debug.Log("Save Game");
        playerData.SavePlayerData();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void BackToLobby()
    {
        Debug.Log("Back To Lobby");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings");
        mainPauseScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void CloseSettings()
    {
        Debug.Log("Close Settings");
        mainPauseScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }

    public void OpenHowToPlay()
    {
        Debug.Log("How To Play");
        mainPauseScreen.SetActive(false);
        howToPlayScreen.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        Debug.Log("Close How To Play");
        mainPauseScreen.SetActive(true);
        howToPlayScreen.SetActive(false);
    }
}
