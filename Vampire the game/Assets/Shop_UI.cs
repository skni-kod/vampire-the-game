using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_UI : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            ShopManager.instance.ToggleShop();
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            ShopManager.instance.ToggleShop();
        }
    }
}
