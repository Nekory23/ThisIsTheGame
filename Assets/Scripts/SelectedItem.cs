using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItem : MonoBehaviour
{
    public GameObject[] SlotsTabs = new GameObject[4];

    void ResetSelected() {
        for (int i = 0; i < SlotsTabs.Length; i++) {
            SlotsTabs[i].GetComponent<Image>().color = Color.white;
        }
    }

    public void SelecteSlot(int i) {
        ResetSelected();
        SlotsTabs[i].GetComponent<Image>().color = Color.green;
    }

    void Start() {
        ResetSelected();
    }
}
