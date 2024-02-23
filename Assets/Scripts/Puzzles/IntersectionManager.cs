using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionManager : MonoBehaviour
{
    [SerializeField] private GameObject center;

    public void ToggleIntersection()
    {
        //RotateCenter();
    }

    private void RotateCenter()
    {
        Quaternion centerRotation = center.transform.rotation;

        centerRotation.y += 90f;
        center.transform.Rotate(centerRotation.x, centerRotation.y, centerRotation.z, Space.Self);
    }

}
