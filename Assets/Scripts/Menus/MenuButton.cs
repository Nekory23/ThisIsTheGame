using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuButton : MonoBehaviour
{
    [Header("Menu Title")]
    [SerializeField] private GameObject[] menuTitle;

    [Header("Materials")]
    [SerializeField] private Material DefaultMaterial;
    [SerializeField] private Material HoverMaterial;
    [SerializeField] private Material ClickMaterial;
    [SerializeField] private Material DisabledMaterial;

    [Header("Continue Button")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private bool isContinue;
    private bool isDisabled = false;

    [Header("Events")]
    public UnityEvent OnClick;

    private void Awake()
    {
        if (!isContinue)
            return;
        playerData = new PlayerData();
        playerData.LoadPlayerData();
        if (playerData.levelName == "Tutorial") {
            isDisabled = true;
            DisableButton();
        }
    }

    public void DisableButton()
    {
        for (int i = 0; i < menuTitle.Length; i++)
            menuTitle[i].GetComponent<Renderer>().material = DisabledMaterial;
    }

    private void OnMouseEnter() 
    {
        if (!isDisabled)
            for (int i = 0; i < menuTitle.Length; i++)
                menuTitle[i].GetComponent<Renderer>().material = HoverMaterial;
    }

    private void OnMouseExit() 
    {
        if (!isDisabled)
            for (int i = 0; i < menuTitle.Length; i++)
                menuTitle[i].GetComponent<Renderer>().material = DefaultMaterial;
    }

    private void OnMouseDown() 
    {
        if (!isDisabled)
            for (int i = 0; i < menuTitle.Length; i++)
                menuTitle[i].GetComponent<Renderer>().material = ClickMaterial;
    }

    private void OnMouseUp() 
    {
        if (!isDisabled) {
            for (int i = 0; i < menuTitle.Length; i++)
                menuTitle[i].GetComponent<Renderer>().material = HoverMaterial;
            SetDefaultMaterial();
            OnClick.Invoke();
        }
    }

    public void SetDefaultMaterial()
    {
        for (int i = 0; i < menuTitle.Length; i++)
            menuTitle[i].GetComponent<Renderer>().material = DefaultMaterial;
    }
}
