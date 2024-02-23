using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laboratory : ALevel
{
    private void Awake()
    {
        LevelName = "Laboratory";
    }

    public override void EndLevel()
    {
        GameSystem gameSystem = FindObjectOfType<GameSystem>();

        gameSystem.setIsGameFinished(true);
        gameSystem.RespawnPlayerToLobby();
    }
}
