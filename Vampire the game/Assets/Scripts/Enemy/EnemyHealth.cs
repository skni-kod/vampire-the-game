using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHp;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    private int currentHp;
    private Animator anim;
    void Start()
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
        if(currentHp > 0)
        {
            currentHp -= damage;
            anim.SetTrigger("hurt");
        } else if (currentHp <= 0)
        {
            //anim.SetTrigger("death");
            foreach (Behaviour component in components)
                component.enabled = false;
            GameObject.Destroy(gameObject);
        }
    }
}
