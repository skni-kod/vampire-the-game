using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    private Rigidbody2D rb;
    public bool IsGrounded;
    public LayerMask WhatIsGround;
    public float groundCheckRadius;
    public Transform groundCheck;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
       
        animator.SetFloat("moveSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetBool("Jump", !IsGrounded);
        
        if (Input.GetAxis("Horizontal")> 0f)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            
        }

        if ((IsGrounded == true && Input.GetButtonDown("Jump")))
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }

        var horizontal = Input.GetAxisRaw("Horizontal") ;
        var velocity = rb.velocity;
        velocity.x = horizontal * moveSpeed;
        rb.velocity = velocity;
    }
   
}
