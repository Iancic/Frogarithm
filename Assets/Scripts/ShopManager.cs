using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopMenu;

   public void OpenShop()
   {
        ShopMenu.SetActive(true);
   }

    public void CloseShop()
    {
        ShopMenu.SetActive(false);
    }
}
