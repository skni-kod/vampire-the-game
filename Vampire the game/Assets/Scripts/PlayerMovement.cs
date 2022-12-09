using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    public int  points;
    private Rigidbody2D rb;
    public bool IsGrounded;
    public LayerMask WhatIsGround;
    public float groundCheckRadius;
    public Transform groundCheck;
    public Animator animator;
    public TextMeshProUGUI pointsText;
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
        pointsText.text = points.ToString();
        animator.SetFloat("moveSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if(Input.GetAxis("Horizontal")>-0.01f)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < -0.01f)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }

        if ((IsGrounded == true && Input.GetKeyDown(KeyCode.W)) || (IsGrounded == true && Input.GetKeyDown(KeyCode.Space)))
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }
        
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            points++;
            Destroy(collision.gameObject);
        }
    }
}
