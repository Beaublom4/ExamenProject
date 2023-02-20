using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemScrObj item;
    public int count;

    public void PickUpItem()
    {
        InventoryManager.Instance.AddItem(item, count, gameObject);
    }
}
