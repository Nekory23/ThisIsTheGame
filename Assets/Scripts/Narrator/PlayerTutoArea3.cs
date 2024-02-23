using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutoArea3 : ANarrator
{
    bool enterArea = false;

    public override void OnNotify(PlayerAction action)
    {
        switch (action)
        {
           case PlayerAction.ENTER_AREA:
                if (!enterArea)
                    RunAudioClip("Narrator/Tutorial/NiceJump");
                enterArea = true;
                break;
            default:
                break;
        }
    }
}