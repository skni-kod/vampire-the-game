using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    public Text coinsText;

    void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Coin")
        {

            ShopManager.instance.coins++ ;


            Destroy(collision.gameObject);

        }

      
    }
    private void OnGUI()
    {
        coinsText.text =  ShopManager.instance.coins.ToString();
    }
}

