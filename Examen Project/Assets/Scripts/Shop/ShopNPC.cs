using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{
    public ShopItem[] shopItems;

    /// <summary>
    /// Opns shop of this NPC and sends it to shop manager
    /// </summary>
    public void OpenShop()
    {
        ShopManager.Instance.OpenShop(shopItems);
    }
}