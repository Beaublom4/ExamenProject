using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public GameObject inventory;
    [Space]
    public Slot meleeSlot;
    public Slot rangeSlot, magicSlot, shieldSlot;
    public Slot[] itemSlots;
    [Space]
    public TMP_Text itemName;
    public TMP_Text itemDiscription;
    public Image itemImage;
    private Slot currentSlot;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
        }
    }
    public void AddItem(ItemScrObj item, int count, GameObject itemObj)
    {
        if (item.melee)
        {
            meleeSlot.SetSlot(item, count);
        }
        else if (item.range)
        {
            rangeSlot.SetSlot(item, count);
        }
        else if (item.magic)
        {
            magicSlot.SetSlot(item, count);
        }
        else if (item.shield)
        {
            shieldSlot.SetSlot(item, count);
        }
        else
        {
            int slot = FindSlot(item);
            if (slot == -1)
                return;
            itemSlots[slot].SetSlot(item, count);
        }

        if (itemObj != null)
            Destroy(itemObj);
    }
    public void RemoveItem(ItemScrObj item, int count)
    {
        foreach(Slot s in itemSlots)
        {
            if(s.item == item)
            {
                if (s.count - count > 0)
                {
                    s.count -= count;
                }
                else
                    s.EmptySlot();
            }
        }
    }
    public int FindSlot(ItemScrObj item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == item)
                return i;
        }
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
                return i;
        }
        
        return -1;
    }
    public bool HasItem(ItemScrObj item, int count)
    {
        foreach(Slot s in itemSlots)
        {
            if(item == s.item)
            {
                if(s.count >= count)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void DisplayItem(Slot slot)
    {
        currentSlot = slot;

        itemName.text = currentSlot.item.itemName;
        itemDiscription.text = currentSlot.item.itemDiscription;
        itemImage.sprite = currentSlot.item.itemIcon;
    }
    public void UseCurrentItem()
    {
        if (currentSlot.item.food)
        {
            //Heal
            Debug.Log($"Heal for {currentSlot.item.healAmount}");
            RemoveItem(currentSlot.item, 1);
        }
    }
}
