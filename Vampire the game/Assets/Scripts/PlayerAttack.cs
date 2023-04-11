using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireskulls;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }
    
    private void Attack()
    {
        anim.SetTrigger("rattack");
        cooldownTimer = 0;
       


            fireskulls[FindFireskull()].transform.position = firePoint.position,firePoint.rotation;
            fireskulls[FindFireskull()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

        
    }

    private int FindFireskull()
    {
        for (int i = 0; i < fireskulls.Length; i++)
        {
            if (!fireskulls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
