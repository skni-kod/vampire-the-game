using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour, ISaveable
{
    [Header ("Movement Parameters")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    [Header("Knockback")]
    [SerializeField] private Transform _center;

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

    public bool canAttack()
    {
        return IsGrounded && (Input.GetAxis("Horizontal") == 0);
    }
    public object SaveState()
    {
        return new SaveData()
        {
            x = this.transform.position.x,
            y = this.transform.position.y
        };
    }
    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        Vector2 poz = new Vector2(saveData.x, saveData.y);
        rb.position = poz;
    }

    [System.Serializable]
    private struct SaveData
    {
        public float x;
        public float y;
    }
}
