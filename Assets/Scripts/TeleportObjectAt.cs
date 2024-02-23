using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObjectAt : MonoBehaviour
{
    public Transform teleportTo;
    public GameObject objectToTeleport;

    public void Teleport()
    {
        objectToTeleport.transform.position = teleportTo.position;
    }
}
