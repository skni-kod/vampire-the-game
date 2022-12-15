using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    protected int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(currentHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    public void healHealth(int health)
    {
        currentHealth += health;
        healthBar.setHealth(currentHealth);
    }

    public int CurrentHealth()
    {
        return currentHealth;
    }

    public int MaxHealth()
    {
        return maxHealth;
    }
}
