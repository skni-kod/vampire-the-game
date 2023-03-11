using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private int maxHp;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    private int currentHp;
    private Animator anim;
    private bool dead;
    //private PlayerMovement playerMovement;
    // Start is called before the first frame update

    void Awake()
    {
        maxHp = 100;
        currentHp = maxHp;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void takeDamage(int damage)
    {
        currentHp -= damage;
        anim.SetTrigger("hurt");

        if(currentHp <= 0)
        {
            dead = true;
            velocityUponDeath();
            anim.SetTrigger("death");
            //GetComponent<PlayerMovement>().moveSpeed = 0;
            foreach (Behaviour component in components)
            {
                if(component != null)
                    component.enabled = false;
            }
        }
    }

    public void restoreHealth(int health)
    {
        currentHp += health;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
    public int getMaxHp()
    {
        return maxHp;
    }

    public int getCurrentHp()
    {
        return currentHp;
    }

    public bool velocityUponDeath()
    {
        if (dead == true)
        {
            return true;
        }
        else return false;
    }
}
