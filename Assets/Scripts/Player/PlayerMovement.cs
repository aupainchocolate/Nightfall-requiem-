using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Gameplay properties

    // Horizontal player keyboard input
    //  -1 = Left
    //   0 = No input
    //   1 = Right
    private float playerInput = 0;
    public float moveSpeed = 10f;
    public float jumpForce = 100f;

    private Rigidbody2D rb;
    [SerializeField] bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    // Horizontal player speed
    [SerializeField] private float speed = 250;

    #endregion

    #region Initialisation methods

    // Initialises this component
    // (NB: Is called automatically before the first frame update)
    void Start()
    {
        // Get component references
        rb = GetComponent<Rigidbody2D>();
        health = MaxHealth;
    }

    #endregion

    #region Gameplay methods

    void Update()
    {
      
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = moveVelocity;

        // Check if the player is grounded
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Debug.Log("Should be jumping, try setting jumpforce higher or gravity lower?");
            rb.AddForce(transform.up * jumpForce);
        }

        // NB: Here, you might want to set the player's animation,
        // e.g. idle or walking
        playerInput = Input.GetAxisRaw("Horizontal");

        // Swap the player sprite scale to face the movement direction
        SwapSprite();
    }

    // Swap the player sprite scale to face the movement direction
    void SwapSprite()
    {
        // Right
        if (playerInput > 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
        // Left
        else if (playerInput < 0)
        {
            transform.localScale = new Vector3(
                -1 * Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }

    // Is called automatically every physics step
    void FixedUpdate()
    {
        // Move the player horizontally
        rb.velocity = new Vector2(
            playerInput * speed * Time.fixedDeltaTime,
            0
        );
    }

    #endregion

    #region PlayerHealth
   
    //keeps track of player's current health
    public int health;

    // How much health you have when you have full health
    public int MaxHealth = 10;

    // Start is called before the first frame update


    //Will be called everytime player takes damage
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
