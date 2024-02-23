using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutoArea2 : ANarrator
{
    static int enterArea = 0;

    public override void OnNotify(PlayerAction action)
    {
        switch (action)
        {
            case PlayerAction.ENTER_AREA:
            enterArea++;

                if (enterArea == 1) {
                    RunAudioClip("Narrator/Tutorial/NeedTheKey");
                } else if (enterArea <= 4) {
                    RunAudioClip("Narrator/Tutorial/NeedTheKey2");
                }
                else if (enterArea == 5) {
                    RunAudioClip("Narrator/Tutorial/NeedTheKey3");
                }
                break;
            default:
                break;
        }
    }
}