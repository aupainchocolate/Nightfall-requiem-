using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 100f;

    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

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
            Debug.Log("Han borde hoppa f�r fan!");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = moveVelocity;

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}