using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : ALevel
{
    private void Awake()
    {
        LevelName = "Tutorial";
    }

    public override void EndLevel()
    {
        GameSystem gameSystem = FindObjectOfType<GameSystem>();

        gameSystem.setCurrentLevel("Laboratory");
        gameSystem.RespawnPlayerToLobby();
    }
}
