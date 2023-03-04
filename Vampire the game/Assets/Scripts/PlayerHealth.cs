using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHp;
    private int currentHp;
    // Start is called before the first frame update
    void Awake()
    {
        maxHp = 100;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            GameObject.Destroy(gameObject);
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
