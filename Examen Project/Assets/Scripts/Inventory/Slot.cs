using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public ItemScrObj item;

    public TMP_Text itemText;
    public Image itemImage;

    /// <summary>
    /// Puts item in a slot and updates slot
    /// </summary>
    public void SetSlot(ItemScrObj _item)
    {
        item = _item;
        UpdateSlot(item.itemName, item.itemIcon);
    }
    /// <summary>
    /// Empties slot and updates slot
    /// </summary>
    public void EmptySlot()
    {

    }
    /// <summary>
    /// Set display slot to variables
    /// </summary>
    public void UpdateSlot(string itemName, Sprite itemSprite)
    {
        itemText.text = itemName;
        itemImage.sprite = itemSprite;
    }
}
