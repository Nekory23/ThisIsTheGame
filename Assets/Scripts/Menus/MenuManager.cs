using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] private PlayerData playerData;

    [Header("Menus")]
    [SerializeField] private GameObject menuTitle;
    [SerializeField] private GameObject menuSettings;
    [SerializeField] private GameObject menuHowToPlay;
    [SerializeField] private GameObject menuStart;

    private void Awake()
    {
        playerData = new PlayerData();
        playerData.LoadPlayerData();
    }

    // MAIN MENU
    public void StartGame()
    {
        if (playerData.levelName == "Tutorial")
        {
            Debug.Log("No data");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
        else
        {
            Debug.Log("Are you sure?");
            menuStart.SetActive(true);
            menuTitle.SetActive(false);
        }   
    }

    public void ContinueGame()
    {
        Debug.Log("Continue Game");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        Debug.Log("Open Settings");
        menuTitle.SetActive(false);
        menuSettings.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    // SETTINGS MENU
    public void CloseSettings()
    {
        Debug.Log("Close Settings");
        menuTitle.SetActive(true);
        menuSettings.SetActive(false);
    }

    public void OpenHowToPlay()
    {
        Debug.Log("Open How To Play");
        menuTitle.SetActive(false);
        menuHowToPlay.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        Debug.Log("Close How To Play");
        menuTitle.SetActive(true);
        menuHowToPlay.SetActive(false);
    }

    // START MENU
    public void StartNewGame()
    {
        Debug.Log("Start New Game");
        playerData = new PlayerData();
        playerData.SavePlayerData();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void CancelNewGame()
    {
        Debug.Log("Cancel New Game");
        menuStart.SetActive(false);
        menuTitle.SetActive(true); 
    }
}
