using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private Light[] lights;
    
    public void OnTriggerEnter(Collider other)
    {
        foreach (Light light in lights)
            light.enabled = true;
    }

    public void OnTriggerExit(Collider other)
    {
        foreach (Light light in lights)
            light.enabled = false;
    }
}
