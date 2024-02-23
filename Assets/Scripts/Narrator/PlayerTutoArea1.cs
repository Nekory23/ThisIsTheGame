using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutoArea1 : ANarrator
{
    bool enterArea = false;

    public override void OnNotify(PlayerAction action)
    {
        switch (action)
        {
            case PlayerAction.ENTER_AREA:
                if (!enterArea)
                    RunAudioClip("Narrator/Tutorial/Greeting");
                enterArea = true;
                break;
            default:
                break;
        }
    }
}