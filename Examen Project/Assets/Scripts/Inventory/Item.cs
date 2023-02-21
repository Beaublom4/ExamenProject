using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemScrObj item;
    public int count;

    /// <summary>
    /// Pick up this item and send it to inventory
    /// </summary>
    public void PickUpItem()
    {
        InventoryManager.Instance.AddItem(item, count, gameObject);
    }
}
