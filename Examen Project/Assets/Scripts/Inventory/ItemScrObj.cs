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

    [Header("Melee")]
    public bool melee;
    public float meleeDamage;
    public float meleeCooldown;
    [Header("Shield")]
    public bool shield;
    public float shieldDuration;
    public float shieldCooldown;
    [Header("Range")]
    public bool range;
    [Header("Magic")]
    public bool magic;
    [Header("Food")]
    public bool food;
    public int healAmount;
    [Header("Key Item")]
    public bool keyItem;
}
