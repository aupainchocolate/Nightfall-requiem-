using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth;   // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health when the enemy spawns
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Subtract damage amount from current health

        // Check if the enemy is dead
        if (currentHealth <= 0)
        {
            Die(); // Call Die function when enemy's health reaches zero or below
        }
    }

    void Die()
    {
        // Play death animation, particle effects, or any other death-related logic
        Debug.Log("Enemy died!"); // For testing purposes, you can replace this with your actual death logic

        // Destroy the enemy game object
        Destroy(gameObject);
    }
}
