using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaging : MonoBehaviour
{
    //lets the damaging script know where to find the script in unity
    public CharacterHealth characterHealth;

    //allows us to set different values to each monster
    public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //is called whenever something enters enemy's collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Check if characterHealth is not null before calling the method
            if (characterHealth != null)
            {
                // Call the TakeDamage method on the characterHealth instance
                characterHealth.TakeDamage(damage);
            }
        }
    }
}
