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

    public void Change_Function_Grade_I()
    {
        Player.Instance.quest_type = 1;
    }

    public void Change_Power()
    {
        Player.Instance.quest_type = 2;
    }

    public void Change_Sqrt()
    {
        Player.Instance.quest_type = 3;
    }

    public void SecretHat()
    {
        if(Player.Instance.pollywags >= 1000)
        {
            Player.Instance.SecretHat();
            Player.Instance.pollywags -= 1250;
        }
    }
}
