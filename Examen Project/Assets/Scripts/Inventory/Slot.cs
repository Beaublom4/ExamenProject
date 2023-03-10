using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public ItemScrObj item;
    public int count;

    public Image itemImage;
    public TMP_Text itemNumber;

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
        itemImage.sprite = null;
        itemImage.color = new Color(255, 255, 255, 0);
        itemNumber.gameObject.SetActive(false);
    }
    /// <summary>
    /// Set display slot to variables
    /// </summary>
    public void UpdateSlot(string itemName, Sprite itemSprite)
    {
        itemImage.sprite = itemSprite;
        itemImage.color = new Color(255, 255, 255, 1);
        itemNumber.gameObject.SetActive(true);
        itemNumber.text = count.ToString();
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
