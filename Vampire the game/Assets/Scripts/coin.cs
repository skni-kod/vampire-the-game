using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coin : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI pointsText;
    public Animator animator;

    void Update()
    {
        pointsText.text = points.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.tag == "Coin")
        {
            points++;


            Destroy(collision.gameObject);

        }
        if (collision.tag == "Door")
        {
            animator.SetTrigger("door_open");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Door")
        {
            animator.SetTrigger("door_close");
        }
    }
}

