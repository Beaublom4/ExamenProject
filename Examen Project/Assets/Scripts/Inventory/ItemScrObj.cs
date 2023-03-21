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
    public int meleeDamage;
    public float meleeCooldown;
    [Header("Shield")]
    public bool shield;
    public float shieldDuration;
    public float shieldCooldown;
    [Header("Range")]
    public bool range;
    public float rangeDamage;
    public float rangeCooldown;
    [Header("Magic")]
    public bool magic;
    public float magicDamage;
    public float magicCooldown;
    public float magicRange;
    [Header("Food")]
    public bool food;
    public int healAmount;
    [Header("Key Item")]
    public bool keyItem;
}
