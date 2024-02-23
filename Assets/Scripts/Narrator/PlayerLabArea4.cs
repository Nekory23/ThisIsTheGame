using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLabArea4 : ANarrator
{
    bool enterArea = false;

    public override void OnNotify(PlayerAction action)
    {
        switch (action)
        {
           case PlayerAction.ENTER_AREA:
                if (!enterArea)
                    RunAudioClip("Narrator/Lab/genius");
                enterArea = true;
                break;
            default:
                break;
        }
    }
}