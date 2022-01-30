using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    // public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask EnemyLayers;
    public MonsterStats stats;
    private float waitTime = 2.0f;
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Attack();
            timer = 0;
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
            if (enemy.gameObject.tag == "Player") {
                TakeDamagePlayer dealDamage = enemy.gameObject.GetComponent<TakeDamagePlayer>();
                dealDamage.ReduceHealthPlayer(stats.damage);
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