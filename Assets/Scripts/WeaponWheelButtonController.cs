using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class WeaponWheelButtonController : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private WeaponWheelButton[] weaponWheelButtons;
    public TMP_Text currentItemName;
    public Image selectedItemIcon;

    void Start()
    {
        starterAssetsInputs = GameObject.Find("EtraCharacterAssetBase").GetComponent<StarterAssetsInputs>();
    }

    public void Selected(int iteamSlotID)
    {
        switch (iteamSlotID)
        {
            case 0:
                starterAssetsInputs.item0Select = true;
                break;
            case 1:
                starterAssetsInputs.item1Select = true;
                break;
            case 2:
                starterAssetsInputs.item2Select = true;
                break;
            case 3:
                starterAssetsInputs.item3Select = true;
                break;
        }
        selectedItemIcon.sprite = weaponWheelButtons[iteamSlotID].GetSelectedIcon();
        starterAssetsInputs.showItemWheel = true;
    }

    public void OnHover(int index)
    {
        weaponWheelButtons[index].HoverEnter();
        currentItemName.text = weaponWheelButtons[index].itemName;
    }

    public void OnHoverExit(int index)
    {
        weaponWheelButtons[index].HoverExit();
    }
}
