using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerMovement : MonoBehaviour, ISaveable
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
    public object SaveState() //funkcja do zapisania pozycji postaci
    {
        return new SaveData()
        {
            x = this.transform.position.x,
            y = this.transform.position.y
        };
    }
    public void LoadState(object state) //funkcja do wczytania pozycji postaci z zapisu
    {
        var saveData = (SaveData)state;
        Vector2 poz = new Vector2(saveData.x, saveData.y);
        rb.position = poz;
    }
    [Serializable]
    private struct SaveData //Struktura pozycji postaci do zapisu
    {
        public float x;
        public float y;
    }
}
