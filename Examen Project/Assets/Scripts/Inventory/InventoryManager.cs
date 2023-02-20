using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Slot meleeSlot, rangeSlot, magicSlot, shieldSlot;
    public Slot[] itemSlots;

    public ItemScrObj testItem;
    [ContextMenu("Add test item")]
    public void TestAddItem()
    {
        if(testItem != null)
            AddItem(testItem);
    }

    public void AddItem(ItemScrObj item)
    {
        if (item.melee)
        {
            meleeSlot.SetSlot(item);
        }
        else
        {

        }
    }
    public void RemoveItem()
    {

    }
    public void FindFirstEmptySlot()
    {

    }
}
