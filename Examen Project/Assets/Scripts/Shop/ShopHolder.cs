using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopHolder : MonoBehaviour
{
    public TMP_Text itemPrice;
    public TMP_Text itemName;
    public Image itemIcon;
    public TMP_Text itemsLeft;

    /// <summary>
    /// Set up shop buy button with all info
    /// </summary>
    /// <param name="_item"></param>
    /// <param name="_itemPrice"></param>
    /// <param name="_itemsLeft"></param>
    public void SetUp(ItemScrObj _item, int _itemPrice, int _itemsLeft)
    {
        itemPrice.text = "Price: " + _itemPrice;
        itemName.text = _item.itemName;
        itemIcon.sprite = _item.itemIcon;
        itemsLeft.text = "Items left: " + _itemsLeft;
    }
    /// <summary>
    /// Buy this item
    /// </summary>
    public void Buy()
    {

    }
}
