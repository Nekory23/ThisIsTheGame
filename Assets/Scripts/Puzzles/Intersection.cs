using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    [SerializeField] private GameObject[] treadmills;
    [SerializeField] private int index;

    public void changeTreadmillDirection()
    {
        int prev = index;

        if (index == treadmills.Length - 1)
            index = 0;
        else
            index++;
        treadmills[index].SetActive(true);
        treadmills[prev].SetActive(false);
    }
}
