using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public LayerMask enemyLayers;

    public float attactRate = 2f;
    private float nextAttackTime = 0f;

    void Update()
    {   
        if (Time.time >= nextAttackTime){
            
            if (Input.GetKeyDown(KeyCode.C)){
                Attack();
                nextAttackTime = Time.time + 1f / attactRate;
            }
        }
    }


    public void Attack(){
        // play attack animation
        animator.SetTrigger("AttackNow");
        AudioManager.instance.Play("attack");
        // detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);

        // damage dealt
        foreach(Collider2D enemey in hitEnemies){
            enemey.GetComponent<Enemey>().TakeDamage(attackDamage);
            Debug.Log("We Hit " + enemey.name);
        }
    }

    private void OnDrawGizmos() {
        if (attackpoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);

    }




}
