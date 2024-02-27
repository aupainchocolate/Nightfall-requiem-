using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;

    [SerializeField] Transform groundCheckPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    void Update()
    {
        Debug.Log(isGrounded);
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Han borde hoppa för fan!");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = moveVelocity;

        //Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, 0.2f, LayerMask.GetMask("Ground"));

        
    }
}