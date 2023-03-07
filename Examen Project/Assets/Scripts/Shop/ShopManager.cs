using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public GameObject shopItemPrefab;
    public Transform shopItemsHolder;
    public GameObject shopObj;

    private void Awake()
    {
        Instance = this;
    }
    /// <summary>
    /// Opens shop panel
    /// </summary>
    /// <param name="shopItems"></param>
    public void OpenShop(ShopItem[] shopItems)
    {
        FindObjectOfType<PlayerMovement>().canMove = false;

        foreach (Transform t in shopItemsHolder)
            Destroy(t.gameObject);
        foreach(ShopItem si in shopItems)
        {
            GameObject g = Instantiate(shopItemPrefab, shopItemsHolder);
            g.GetComponent<ShopHolder>().SetUp(si);
        }
        shopObj.SetActive(true);
    }
    /// <summary>
    /// Closes shop ui
    /// </summary>
    public void CloseShop()
    {
        FindObjectOfType<PlayerMovement>().canMove = true;
        shopObj.SetActive(false);
    }
    /// <summary>
    /// Buy item that has been clicked and add it to inventory
    /// </summary>
    /// <param name="item"></param>
    public void BuyItem(ShopItem item)
    {
        if (InventoryManager.Instance.coins < item.price)
            return;
        InventoryManager.Instance.coins -= item.price;
        HudManager.Instance.SetCoins(InventoryManager.Instance.coins);
        InventoryManager.Instance.AddItem(item.item, 1, null);
        item.currentInStore--;
    }
}
[System.Serializable]
public class ShopItem
{
    public ItemScrObj item;
    public int price;
    public int currentInStore;
}
