using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLobbyArea1 : ANarrator
{
    static int enterArea = 0;

    public override void OnNotify(PlayerAction action)
    {
        switch (action)
        {
            case PlayerAction.ENTER_AREA:
            enterArea++;

                if (enterArea == 1) {
                    RunAudioClip("Narrator/Lobby/NewRoom");
                } else if (enterArea <= 4) {
                    RunAudioClip("Narrator/Lobby/NewRoom");
                }
                else if (enterArea == 5) {
                    RunAudioClip("Narrator/Lobby/NewRoom");
                }
                break;
            default:
                break;
        }
    }
}