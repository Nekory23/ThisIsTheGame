using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseActivator : MonoBehaviour
{
    public GameObject cursor1;
    public GameObject cursor2;

    public void LockMouse()
    {
        ABILITY_CameraMovement cameraMovement = GameObject.Find("EtraAbilityManager").GetComponent<ABILITY_CameraMovement>();
        cameraMovement.abilityEnabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (cursor1)
        {
            cursor1.SetActive(true);
        }
        if (cursor2)
        {
            cursor2.SetActive(true);
        }
    }

    public void UnlockMouse()
    {
        ABILITY_CameraMovement cameraMovement = GameObject.Find("EtraAbilityManager").GetComponent<ABILITY_CameraMovement>();
        cameraMovement.abilityEnabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (cursor1)
        {
            cursor1.SetActive(false);
        }
        if (cursor2)
        {
            cursor2.SetActive(false);
        }
    }
}
