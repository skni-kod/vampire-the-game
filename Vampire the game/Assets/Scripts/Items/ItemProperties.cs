using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties : MonoBehaviour
{
    [SerializeField] private int ID;
    private bool canPickUp = false;
    void Start()
    {

    }

    void Update()
    {
        if(canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            if (ItemsDataBase.Instance.playerItems.Count < InventoryManager.GetInventorySlots())
            {
                ItemsDataBase.Instance.playerItems.Add(ItemsDataBase.Instance.items[ID]);
                Destroy(this.gameObject);
            }
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canPickUp = false;
        }
    }

    public int GetID()
    {
        return ID;
    }
}
