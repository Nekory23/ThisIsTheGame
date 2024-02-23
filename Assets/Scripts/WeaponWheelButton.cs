using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponWheelButton : MonoBehaviour
{
    public Animator anim;
    public string itemName;
    public Sprite selectedItem;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public Sprite GetSelectedIcon()
    {
        return selectedItem;
    }

    public void HoverEnter()
    {
        anim.SetBool("Hover", true);
    }

    public void HoverExit()
    {
        anim.SetBool("Hover", false);
    }
}
