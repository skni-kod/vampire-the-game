using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    [SerializeField] private int potionPoints = 20;
    PlayerHealth playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && playerHealth.getCurrentHp() != playerHealth.getMaxHp())
        {
            playerHealth.restoreHealth(potionPoints);
            GameObject.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
