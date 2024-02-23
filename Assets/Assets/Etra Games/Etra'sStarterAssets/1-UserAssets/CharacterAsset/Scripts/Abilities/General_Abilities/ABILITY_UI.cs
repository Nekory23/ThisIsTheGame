using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class ABILITY_UI : EtraAbilityBaseClass
{
    [Header("Basics")]

    [SerializeField] private GameObject pauseMenu;
    StarterAssetsInputs starterAssetsInputs;
    
    ABILITY_CameraMovement ability_CameraMovement;
    ABILITY_CharacterMovement ability_CharacterMovement;
    ABILITY_Inventory ability_Inventory;
    GameObject fpsCamera;
    GameObject etraAssetCanvas;
    public bool isPaused = false;

    public override void abilityStart()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        
        ability_CameraMovement = GetComponent<ABILITY_CameraMovement>();
        ability_CharacterMovement = GetComponent<ABILITY_CharacterMovement>();
        ability_Inventory = GetComponent<ABILITY_Inventory>();
    
        fpsCamera = GameObject.Find("FPSUsableItemsCamera");
        etraAssetCanvas = GameObject.Find("EtraCharacterAssetCanvas");
    }

    public override void abilityUpdate()
    {
        if (!enabled)
        {
            return;
        }

        if (starterAssetsInputs.pauseGame)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                OnPauseGame();
            }
            else
            {
                OnResumeGame();
            }
            starterAssetsInputs.pauseGame = false;
        }
    }

    public void OnPauseGame()
    {
        StartCoroutine(OnPauseGameCoroutine());
    }

    IEnumerator OnPauseGameCoroutine()
    {
        if (ability_Inventory.weaponWheelSelected == true) {
            ability_Inventory.ForceToHideWeaponWheel();
            yield return new WaitForSeconds(0.8f);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ability_CameraMovement.abilityEnabled = false;
        ability_CharacterMovement.abilityEnabled = false;

        pauseMenu.transform.position = fpsCamera.transform.position + fpsCamera.transform.forward * 2f + fpsCamera.transform.right * -0.5f;
        pauseMenu.transform.rotation = fpsCamera.transform.rotation;

        etraAssetCanvas.SetActive(false);
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void OnResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ability_CameraMovement.abilityEnabled = true;
        ability_CharacterMovement.abilityEnabled = true;

        etraAssetCanvas.SetActive(true);
        pauseMenu.SetActive(false);
        isPaused = false;
    }
}
