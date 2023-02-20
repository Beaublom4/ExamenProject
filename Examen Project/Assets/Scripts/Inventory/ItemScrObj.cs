using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemScrObj : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    [TextArea]
    public string itemDiscription;
    public int itemId;

    [Header("Weapon Type")]
    public bool melee;
    public bool range;
    public bool magic;
    public bool shield;
    [Header("Food")]
    public bool food;
    public int healAmount;
    [Header("Key Item")]
    public bool keyItem;
}
