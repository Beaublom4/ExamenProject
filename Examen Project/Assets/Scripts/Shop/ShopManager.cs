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
        foreach(ShopItem si in shopItems)
        {
            GameObject g = Instantiate(shopItemPrefab, shopItemsHolder);
            g.GetComponent<ShopHolder>().SetUp(si.item, si.price, si.maxInStore);
        }
    }
}
[System.Serializable]
public class ShopItem
{
    public ItemScrObj item;
    public int price;
    public int maxInStore;
}
