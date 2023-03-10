using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    public static int points = 0;
  

    void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Coin")
        {
            ShopManager.instance.coins++;

            points++;
            Destroy(collision.gameObject);
        }
        
    }
   
}
