using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private bool isGrounded; // Flag to track whether the object is grounded or not

    // Define the ground layer mask to check for ground collision
    public LayerMask groundLayerMask;

    // Define the ground check transform to determine ground detection position
    public Transform groundCheckTransform;

    // Define the ground check radius for detecting ground collision
    public float groundCheckRadius = 0.1f;

    void Update()
    {
        // Check if the object is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayerMask);
    }

    // Method to check if the object is grounded
    public bool IsGrounded()
    {
        return isGrounded;
    }

    // Method to draw ground check gizmos in the Unity Editor for visualization
    private void OnDrawGizmosSelected()
    {
        if (groundCheckTransform != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
        }
    }
}