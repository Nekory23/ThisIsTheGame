using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ABILITY_Inventory : EtraAbilityBaseClass
{
    [Header("Basics")]

    public UsableItem[] inventory = new UsableItem[10];
    public Animator anim;
    public bool weaponWheelSelected = false;

    StarterAssetsInputs starterAssetsInputs;
    ABILITY_UI ability_UI;

    public override void abilityStart()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        ability_UI = GetComponent<ABILITY_UI>();
    }

    public override void abilityUpdate()
    {
        if (!enabled || ability_UI.isPaused)
        {
            starterAssetsInputs.showItemWheel = false;
            return;
        }

        if (starterAssetsInputs.showItemWheel)
        {
            weaponWheelSelected = !weaponWheelSelected;
            if (weaponWheelSelected == true)
            {
                anim.SetBool("OpenWeaponWheel", true);
            }
            else
            {
                anim.SetBool("OpenWeaponWheel", false);
            }
            starterAssetsInputs.showItemWheel = false;
        }

    }

    public bool AddItem(UsableItem item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                return true;
            }
        }
        return false;
    }

    public UsableItem HasItem(UsableItem.UsableItemType type)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].usableItemType == type)
                {
                    return inventory[i];
                }
            }
        }
        return null;
    }

    public void RemoveItem(UsableItem item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                inventory[i] = null;
                return;
            }
        }
    }

    public void ForceToHideWeaponWheel()
    {
        anim.SetBool("OpenWeaponWheel", false);
        weaponWheelSelected = false;
        starterAssetsInputs.showItemWheel = false;
    }
}
