using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLabArea1 : ANarrator
{
    bool enterArea = false;

    public override void OnNotify(PlayerAction action)
    {
        switch (action)
        {
           case PlayerAction.ENTER_AREA:
                if (!enterArea)
                    RunAudioClip("Narrator/Lab/Laboratory");
                enterArea = true;
                break;
            default:
                break;
        }
    }
}