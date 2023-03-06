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

    private ShopItem item;

    /// <summary>
    /// Set up shop buy button with all info
    /// </summary>
    /// <param name="_item"></param>
    /// <param name="_itemPrice"></param>
    /// <param name="_itemsLeft"></param>
    public void SetUp(ShopItem _item)
    {
        item = _item;   

        itemPrice.text = "Price: " + _item.price;
        itemName.text = _item.item.itemName;
        itemIcon.sprite = _item.item.itemIcon;
        itemsLeft.text = "Items left: " + _item.currentInStore;
    }
    /// <summary>
    /// Buy this item
    /// </summary>
    public void Buy()
    {
        if (item.currentInStore <= 0)
            return;
        ShopManager.Instance.BuyItem(item);
        itemsLeft.text = "Items left: " + item.currentInStore;
    }
}
