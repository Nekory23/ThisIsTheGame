using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EasterEgg {
    PORTAL_CUBE,
    MiCROWAVE_HALFLIFE,
};

[System.Serializable]
public class PlayerData
{
    public string levelName;
    public bool finishGame;
    public bool[] easterEgg;
    public PlayerData()
    {
        this.levelName = "Tutorial";
        this.finishGame = false;
        this.easterEgg = new bool[EasterEgg.GetNames(typeof(EasterEgg)).Length];
    }

    public PlayerData(string levelName, bool finishGame, bool[] easterEgg)
    {
        this.levelName = levelName;
        this.finishGame = finishGame;
        this.easterEgg = easterEgg;
    }

    public void SetEasterEgg(EasterEgg easterEgg, bool value)
    {
        this.easterEgg[(int)easterEgg] = value;
    }

    public bool GetEasterEgg(EasterEgg easterEgg)
    {
        return this.easterEgg[(int)easterEgg];
    }

    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayerData()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        levelName = data.levelName;
        finishGame = data.finishGame;
        easterEgg = data.easterEgg;
    }
}
