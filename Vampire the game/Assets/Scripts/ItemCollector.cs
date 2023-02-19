using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private int healHealth = 20;
    public PlayerHealth player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Potion Health") && player.CurrentHealth() < player.MaxHealth())
        {
            Destroy(collision.gameObject);
            player.healHealth(healHealth);
        }
    }
}
