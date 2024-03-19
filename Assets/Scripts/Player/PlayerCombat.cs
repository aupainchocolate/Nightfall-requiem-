using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage= 50;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("i attack funk");
        // Play an attack animation
        animator.SetTrigger("Player");

        // Detect enemies in range of attack
       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Damage enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            var enemyScript = enemy.gameObject.GetComponent<EnemyScript>();
            if(enemyScript != null )
            {
                Debug.Log(enemy.gameObject.name);
                enemyScript.TakeDamage(attackDamage);
            }
            else { Debug.Log("ingen fiende"); }
       
            Debug.Log("Hit" + enemy.name);

            //EnemyScript har döpts om till EnemyMovement
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
