using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 3f; // Adjust this value to control the speed of the enemy
    public Transform groundDetection; // Transform to detect ground in front of the enemy

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move the enemy
        rb.velocity = new Vector2(moveSpeed * (isFacingRight ? 1 : -1), rb.velocity.y);

        // Check if there's ground in front of the enemy
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.5f);

        // If there's no ground, flip the enemy
        if (!groundInfo.collider)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the direction the enemy is facing
        isFacingRight = !isFacingRight;

        // Flip the enemy sprite
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the enemy collides with the player, you can add damage logic or other behaviors here
        if (collision.CompareTag("Player"))
        {
            // For example, you might decrease player health, play a sound, etc.
            Debug.Log("Enemy collided with player!");
        }
    }
}