using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDevArea2 : ANarrator
{
    int itemSpawned = 0;

    public override void OnNotify(PlayerAction action)
    {
        switch (action)
        {
            case PlayerAction.ACTIVATE_STANDING_BUTTON:
                itemSpawned++;

                if (itemSpawned == 1)
                {
                    RunAudioClip("Narrator/DevArea2/item1");
                }
                else if (itemSpawned <= 4)
                {
                    RunAudioClip("Narrator/DevArea2/item2");
                } else if (itemSpawned == 5)
                {
                    RunAudioClip("Narrator/DevArea2/item3");
                }
                break;
            default:
                break;
        }
    }
}
