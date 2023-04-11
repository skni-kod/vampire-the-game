using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header ("Health")]
     public int maxHp =100;

    private int currentHp;
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
       
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
            anim.SetTrigger("death");
            GetComponent<PlayerMovement>().enabled = false;
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
}
