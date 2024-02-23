using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Usable Item")]
public class UsableItem : Item
{
    public enum UsableItemType {
        Key,
        None,
    };

    [Header("Usable Item Information")]
    public UsableItemType usableItemType = UsableItemType.None;
}
