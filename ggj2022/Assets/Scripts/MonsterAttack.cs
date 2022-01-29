using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    // public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;
    public int attackDamage = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
            enemy.GetComponent<MonsterStats>().hp -= attackDamage;
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