using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillManager : MonoBehaviour
{
    [SerializeField] private GameObject[] list1;
    [SerializeField] private GameObject[] list2;

    // Update is called once per frame
    public void ToggleTreadmills()
    {
        for (int i = 0; i < list1.Length; i++)
        {
            list1[i].gameObject.SetActive(!list1[i].gameObject.activeSelf);
        }
        for (int i = 0; i < list2.Length; i++)
        {
            list2[i].gameObject.SetActive(!list2[i].gameObject.activeSelf);
        }
    }
}
