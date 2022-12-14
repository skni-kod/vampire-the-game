using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI pointsText;
    

    void Update()
    {
        pointsText.text = points.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
        
    {
        if(collision.tag=="Coin")
        {
            points++;
            

            Destroy(collision.gameObject);

        }
    }

}

