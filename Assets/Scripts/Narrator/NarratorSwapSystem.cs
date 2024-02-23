using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorSwapSystem : MonoBehaviour
{
    [SerializeField] private NarratorManager narratorManager;
    [SerializeField] private ANarrator narrator;

    private void Start() {
        narrator = GetComponent<ANarrator>();
        Debug.Assert(narrator != null, "NarratorSwapSystem needs an ANarrator component");
        Debug.Assert(narratorManager != null, "NarratorSwapSystem needs a NarratorManager component");    
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && narrator) {
            narratorManager.narrator = narrator;
        }
    }
}
