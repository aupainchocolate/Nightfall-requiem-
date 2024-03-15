using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A simple health controller for a player in Unity
public class PlayerHealthController : MonoBehaviour
{
    #region Properties

    // The player's health at the start
    [SerializeField] public int healthInitial = 3;

    // The player's health right now
    public int healthCurrent;

    #endregion

    #region Initialisation methods

    // Initialises this component
    // (NB: Is called automatically before the first frame update)
    void Start()
    {
        // Initialiase the player's current health
        ResetHealth();
    }

    // Sets the player's current health back to its initial value
    public void ResetHealth()
    {
        // Reset the player's current health
        healthCurrent = healthInitial;
    }

    #endregion

    #region Gameplay methods

    // Reduces the player's current health
    // (NB: Call this if hit by enemy, activated trap, etc)
    public void TakeDamage(int damageAmount)
    {
        // Deduct the provided damage amount from the player's current health
        healthCurrent -= damageAmount;

        // If the player has no health left now
        if (healthCurrent <= 0)
        {
            // Kill the player
            Destroy(gameObject);

            // NB: Here, you may want to restart the game
            // (e.g. by informing your game manager that the player has died,
            // or by raising an event using your event system)
        }
    }

    // Increase the player's current health
    // (NB: Call this if picked up potion, herb, etc)
    public void Heal(int healAmount)
    {
        // Add the provided heal amount to the player's current health
        healthCurrent += healAmount;

        // If the player has too much health now
        if (healthCurrent > healthInitial)
        {
            // Reset the player's current health
            ResetHealth();
        }
    }

    #endregion
}