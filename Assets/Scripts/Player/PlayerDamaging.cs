using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaging : MonoBehaviour
{
    public int damageAmount = 10;
    private int comboCount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            comboCount++;

            if (comboCount >= 3)
            {
                Attack();
                comboCount = 0;
            }
        }
    }

    void Attack()
    {
        // Här kan du lägga till kod för att skada fiender, till exempel med hjälp av kollision eller en stråle
        Debug.Log("Player orsakade " + damageAmount + " skada på fiender!");
    }
}
