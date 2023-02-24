using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coins : MonoBehaviour
{
    public int coin = 0;
    public TextMeshProUGUI coinsText;
   


    void Update()
    {
        coinsText.text = coin.ToString();
        
    }

    void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Coin")
        {
            coin++;


            Destroy(collision.gameObject);

        }

      
    }

}

