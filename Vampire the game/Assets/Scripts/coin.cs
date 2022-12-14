using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coin : MonoBehaviour
{
    public int points=0;
    public TextMeshProUGUI pointsText;

    void Update()
    {
        pointsText.text = points.ToString();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            points++;

            Destroy(collision.gameObject);
            
        }
    }

}

