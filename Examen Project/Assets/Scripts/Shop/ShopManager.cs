using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    public GameObject shopItemPrefab;
    public Transform shopItemsHolder;
    public GameObject shopObj;
    public GameObject cancelButton;
    public TMP_Text coins;

    private bool canOpen = true;

    public AudioClip buyItem;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!shopObj.activeSelf)
                return;
            CloseShop();
        }
    }
    /// <summary>
    /// Opens shop panel
    /// </summary>
    /// <param name="shopItems"></param>
    public void OpenShop(ShopItem[] shopItems)
    {
        if (!canOpen)
            return;
        canOpen = false;

        FindObjectOfType<PlayerMovement>().canMove = false;
        FindObjectOfType<PlayerCombat>().canAttack = false;
        InventoryManager.Instance.canOpen = false;

        coins.text = InventoryManager.Instance.coins.ToString();

        foreach (Transform t in shopItemsHolder)
            Destroy(t.gameObject);
        foreach(ShopItem si in shopItems)
        {
            GameObject g = Instantiate(shopItemPrefab, shopItemsHolder);
            g.GetComponent<ShopHolder>().SetUp(si);
        }
        shopObj.SetActive(true);

        FindObjectOfType<EventSystem>().SetSelectedGameObject(cancelButton);
    }
    /// <summary>
    /// Closes shop ui
    /// </summary>
    public void CloseShop()
    {
        FindObjectOfType<PlayerMovement>().canMove = true;
        FindObjectOfType<PlayerCombat>().canAttack = true;
        InventoryManager.Instance.canOpen = true;
        shopObj.SetActive(false);
        StartCoroutine(CloseShopDelay());
    }
    IEnumerator CloseShopDelay()
    {
        yield return new WaitForEndOfFrame();
        canOpen = true;
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
        SoundManager.Instance.PlaySound(buyItem, 1);
        coins.text = InventoryManager.Instance.coins.ToString();
    }
}
[System.Serializable]
public class ShopItem
{
    public ItemScrObj item;
    public int price;
    public int currentInStore;
}
