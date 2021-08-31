using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemey : MonoBehaviour
{   
    public GameObject EnemyAI;
    public AIPath aiPath;
    public Animator animator;
    public Transform Enemyattackpoint;
    public float EnemyattackRange = 0.5f;
    public int EnemyattackDamage = 20;
    public LayerMask PlayerLayers;
    public int maxHealth = 100;
    int currentHealth;
    public float attactRate = 2f;
    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {   
        AudioManager.instance.PlaySFX("enemy_grunt");
        currentHealth = maxHealth;
        
    }

    private void Update() {
        
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(Enemyattackpoint.position, EnemyattackRange, PlayerLayers);
        if (Time.time >= nextAttackTime){
            foreach(Collider2D player in hitPlayer){
                animator.SetTrigger("EnemyAttack");
                player.GetComponent<PlayerHealth>().PlayerTakeDamage(EnemyattackDamage);
                nextAttackTime = Time.time + 1f / attactRate;
            }
        }
        if (aiPath.desiredVelocity.x >= 0.01f){
            transform.localScale = new Vector3(-1f,1f,1f);
        } else if (aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(1f,1f,1f);
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        
        // play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0){
            animator.SetTrigger("Hurt");
            Die();
        }
    }
    void Die(){
        Debug.Log("Enemy Died");

        //add score
        ScoreManager.Instance.AddScore();
        
        animator.SetBool("IsDead", true);

        //GetComponent<Collider2D>().enabled = false;
        //GetComponent<BoxCollider2D>().enabled = false;
       // GetComponent<Rigidbody2D>().gravityScale = 0;
        Destroy(EnemyAI, 1f);
        this.enabled = false;
    }

    private void OnDrawGizmos() {
        if (Enemyattackpoint == null){
            return;
        }
        Gizmos.DrawWireSphere(Enemyattackpoint.position, EnemyattackRange);

    }



}
