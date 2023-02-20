using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemScrObj : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int itemId;

    [Header("Weapon Type")]
    public bool melee;
    public bool range;
    public bool magic;
    public bool shield;
    [Header("Item Type")]
    public bool food;
    public bool keyItem;
}
