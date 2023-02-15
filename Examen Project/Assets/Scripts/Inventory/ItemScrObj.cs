using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemScrObj : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int itemId;
}
