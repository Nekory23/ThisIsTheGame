using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobbyArea2 : ANarrator
{
    static int enterArea = 0;

    public override void OnNotify(PlayerAction action)
    {
        
        RunAudioClip("Narrator/Lobby/LetsGo");
                
    }
}