using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public ItemScrObj item;
    public int count;

    public TMP_Text itemText;
    public Image itemImage;

    /// <summary>
    /// Puts item in a slot and updates slot
    /// </summary>
    public void SetSlot(ItemScrObj _item, int _count)
    {
        if (item != null && item != _item)
            EmptySlot();

        if (item == null) 
        {
            item = _item;
            count = _count;
        }
        else
        {
            count += _count;
        }

        UpdateSlot(item.itemName, item.itemIcon);
    }
    /// <summary>
    /// Empties slot and updates slot
    /// </summary>
    public void EmptySlot()
    {
        item = null;
        count = 0;
        itemText.text = "Item";
        itemImage.sprite = null;
    }
    /// <summary>
    /// Set display slot to variables
    /// </summary>
    public void UpdateSlot(string itemName, Sprite itemSprite)
    {
        itemText.text = itemName;
        itemImage.sprite = itemSprite;
    }
    /// <summary>
    /// Use item in slot
    /// </summary>
    public void UseSlot()
    {
        if (item == null)
            return;

        InventoryManager.Instance.DisplayItem(this);
    }
}
