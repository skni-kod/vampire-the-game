using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.tag == "Player")
        {
            animator.SetTrigger("door_open");
        }
    }
    void OnTriggerExit2D(Collider2D cl)
{
    if (cl.tag == "Player")
    {
        animator.SetTrigger("door_close");
    }
}
}
