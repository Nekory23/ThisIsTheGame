using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ALevel : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private int currentSpawnPoint = 0;

    public string LevelName { get => levelName; set => levelName = value; }
    public int CurrentSpawnPoint { get => currentSpawnPoint; set => currentSpawnPoint = value; }

    public GameObject GetSpawnPoint(int index)
    {
        return spawnPoints[index];
    }

    public GameObject GetCurrentSpawnPoint()
    {
        return spawnPoints[currentSpawnPoint];
    }

    public abstract void EndLevel();

    public void FoundEasteregg(string easterEgg)
    {
        GameSystem gameSystem = FindObjectOfType<GameSystem>();
        EasterEgg easterEggEnum = (EasterEgg)System.Enum.Parse(typeof(EasterEgg), easterEgg);

        gameSystem.SetEasterEgg(easterEggEnum, true);
    }

    protected void OnEndLevel()
    {
        GameSystem gameSystem = FindObjectOfType<GameSystem>();

        gameSystem.setIsGameFinished(true);
        gameSystem.RespawnPlayerToLobby();
    }
}
