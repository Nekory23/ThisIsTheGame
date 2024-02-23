using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItemIntercation : ObjectInteraction
{
    public UsableItem usableItem;

    public override void Press()
    {
        base.Press();
        PickupUsableItem();
    }

    private void PickupUsableItem()
    {
        ABILITY_Inventory inventory = GameObject.Find("EtraAbilityManager").GetComponent<ABILITY_Inventory>();
        inventory.AddItem(usableItem);
        Destroy(gameObject);
    }
}
