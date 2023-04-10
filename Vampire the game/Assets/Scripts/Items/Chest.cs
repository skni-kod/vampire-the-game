using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool canOpen = false;
    private Animator animator;
    int value;

 
    
  
    void Start()
    {
        animator = GetComponent<Animator>();

        value = Random.Range(10, 30);
      
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Item item in ItemsDataBase.Instance.playerItems)
        {
            if(item.ID == 1 && canOpen && Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("isOpen", true);
                ItemsDataBase.Instance.playerItems.Remove(item);
                GiveLoot();
                break;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canOpen = false;
        }
    }

    private void GiveLoot()
    {
       ShopManager.instance.coins += value;
    }
    
}
