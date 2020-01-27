using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attRange = 0.1f;
    public int attDmg = 25;
    public float attSpeed = 2f;
    float nextAttT = 0;
    public LayerMask Enemies;
    void Update()
    {
        if (Time.time >= nextAttT)
        {

            if (Input.GetKeyDown(KeyCode.X))
            {
                Attack();
                nextAttT = Time.time + 1f / attSpeed;
            }

        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");

        Collider2D[] hit = Physics2D.OverlapCircleAll(attackPoint.position, attRange, Enemies);
        
        foreach(Collider2D enemy in hit)
        {
            enemy.GetComponent<Robak>().TakeDMG(attDmg);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attRange);
    }
}
