using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;
    public MonsterStats stats;
    public int damage = 2;
    public KeyCode code;

    void Update()
    {
        if (Input.GetKeyDown(code))
        {
            Attack();
        }
    }

    void Attack()
    {
        // faire une attack
        // animator.SetTrigger("Attack");
        // detect les enemy dans la renge d'attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.tag == "Monster") {
                TakeDamage dealDamage = enemy.gameObject.GetComponent<TakeDamage>();
                dealDamage.ReduceHealth(damage);
            }
        }
        // damage au enenmy
    }

    void OnDrawGizmosSelected() 
    {
        if (attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}