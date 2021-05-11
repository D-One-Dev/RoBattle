using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject attackSprite;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f, reloadTime;
    private float timer;
    public bool isOnBoss;
    public LayerMask enemyLayers;

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
        }
    }
    public void Attack()
    {
        if (timer <= 0 && !isOnBoss)
        {
            attackSprite.transform.position = attackPoint.position;
            attackSprite.GetComponent<AttackAnimationController>().AnimationPlay();
            timer = reloadTime;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.GetComponent<EnemyController>() == null) return;
                enemy.GetComponent<EnemyController>().TakeDamage(1);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
