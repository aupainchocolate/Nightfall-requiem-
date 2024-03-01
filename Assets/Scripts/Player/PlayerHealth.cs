using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    //keeps track of player's current health
    public int health; 

    // How much health you have when you have full health
    public int MaxHealth = 10; 

    // Start is called before the first frame update
    void Start()
    {
       health = MaxHealth; 
    }

    //Will be called everytime player takes damage
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            Destroy (gameObject);
        }
    }
}
