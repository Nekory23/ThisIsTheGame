using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject lobbySpawnPoint;
    [SerializeField] private LevelPrefabAndSpawnPoint[] levels;
    [SerializeField] private string currentLevelName;
    [SerializeField] private string previousLevelName = "";
    [SerializeField] private ALevel currentLevel = null;
    [SerializeField] private GameObject doorHandle;
    public bool isGameFinished = false;

    [System.Serializable]
    public class LevelPrefabAndSpawnPoint
    {
        public string levelName;
        public GameObject levelPrefab;
        public GameObject spawnPoint;

        public LevelPrefabAndSpawnPoint(string levelName, GameObject levelPrefab, GameObject spawnPoint)
        {
            this.levelName = levelName;
            this.levelPrefab = levelPrefab;
            this.spawnPoint = spawnPoint;
        }
    }

    private void Awake()
    {
        playerData = new PlayerData();
        playerData.LoadPlayerData();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        Debug.Assert(player != null, "Player is null");
        Debug.Assert(lobbySpawnPoint != null, "Lobby spawn point is null");
        Debug.Assert(levels.Length > 0, "Levels array is empty");
        Debug.Assert(doorHandle != null, "Door handle is null"); 

        isGameFinished = playerData.finishGame;
        if (isGameFinished == false) {
            LoadLevel(playerData.levelName);
            if (playerData.levelName == "Tutorial")
            {
                RespawnPlayerAtLevelSpawnPoint();
            }
            else
            {
                RespawnPlayerToLobby();
            }
        }
        else
        {
            RespawnPlayerToLobby();
        }
    }

    public void setIsGameFinished(bool value)
    {
        isGameFinished = value;
        playerData.finishGame = value;
    }

    public void RespawnPlayerAtLevelSpawnPoint()
    {
        player.transform.position = currentLevel.GetCurrentSpawnPoint().transform.position;
    }

    public void RespawnPlayerToLobby()
    {
        player.transform.position = lobbySpawnPoint.transform.position;
    }

    public void setCurrentLevel(string levelName)
    {
        previousLevelName = currentLevelName;
        currentLevelName = levelName;
        playerData.levelName = levelName;
    }

    public void SavePlayer()
    {
        playerData.SavePlayerData();
    }

    public void FinishLevel()
    {
        if (isGameFinished == true) {
            Debug.Log("Game is finished");
            playerData.SavePlayerData();
            UnloadLevel();
            doorHandle.SetActive(false);
            return;
        }
        if (previousLevelName == "")
            return;
        playerData.SavePlayerData();
        UnloadLevel();
        LoadLevel(currentLevelName);
    }

    public void LoadLevel(string levelName)
    {
        foreach (LevelPrefabAndSpawnPoint level in levels)
        {
            if (level.levelName == levelName) {
                currentLevelName = levelName;
                level.spawnPoint.SetActive(true);
                GameObject obj = Instantiate(level.levelPrefab, level.spawnPoint.transform.position, level.spawnPoint.transform.rotation);
                currentLevel = obj.GetComponent<ALevel>();
                return;
            }
        }
    }

    public void UnloadLevel()
    {
        if (currentLevel == null)
            return;
        Destroy(currentLevel.gameObject);
        currentLevel = null;
    }

    public void SetEasterEgg(EasterEgg easteregg, bool value)
    {
        playerData.SetEasterEgg(easteregg, value);
    }

    public bool GetEasterEgg(EasterEgg easteregg)
    {
        return playerData.GetEasterEgg(easteregg);
    }
}
