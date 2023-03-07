using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public GameObject inventory;
    public int coins;
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
        HudManager.Instance.SetCoins(coins);
    }
    /// <summary>
    /// Update checks input to open inventory
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
            if (inventory.activeSelf)
            {
                ClearDisplay();
            }
        }
    }
    /// <summary>
    /// Add item to inventory with item, count of added items, object to destroy
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    /// <param name="itemObj"></param>
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
    /// <summary>
    /// Remove item from inventory with item and count of item
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
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
    /// <summary>
    /// Find a slot thats or already has item in it or finds empty slot to put item in
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Check in all item slots if item is present en if the count is >= than count
    /// </summary>
    /// <param name="item"></param>
    /// <param name="count"></param>
    /// <returns></returns>
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
    /// <summary>
    /// Shows item in display right on screen with an use button
    /// </summary>
    /// <param name="slot"></param>
    public void DisplayItem(Slot slot)
    {
        currentSlot = slot;

        itemName.text = currentSlot.item.itemName;
        itemDiscription.text = currentSlot.item.itemDiscription;
        itemImage.sprite = currentSlot.item.itemIcon;
    }
    /// <summary>
    /// Clears display from all info
    /// </summary>
    public void ClearDisplay()
    {
        currentSlot = null;

        itemName.text = "";
        itemDiscription.text = "";
        itemImage.sprite = null;
    }
    /// <summary>
    /// Uses current item displayed in display screen
    /// </summary>
    public void UseCurrentItem()
    {
        if (currentSlot == null)
            return;
        if (currentSlot.item.food)
        {
            //Add health that current food item gives
            Debug.Log($"Heal for {currentSlot.item.healAmount}");
            FindObjectOfType<Health>().addHealth(currentSlot.item.healAmount);
            RemoveItem(currentSlot.item, 1);
        }
        if (currentSlot.item == null)
            ClearDisplay();
    }
    /// <summary>
    /// Add coins and update to inventory
    /// </summary>
    public void AddCoin(GameObject coin)
    {
        coins++;
        HudManager.Instance.SetCoins(coins);
        if(coin != null)
            Destroy(coin);
    }
}
