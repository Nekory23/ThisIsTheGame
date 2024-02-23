using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSensibilitySlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("cameraSensitivity", 1f);   
    }
}
