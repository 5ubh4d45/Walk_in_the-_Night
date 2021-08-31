using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class PlayerHealth : MonoBehaviour
{   
    public Animator animator;
    public ShakePreset ShakePreset;
    public Shaker cameraDMGShake;
    public HealthBar healthBar;
    public static bool IsplayerDead = false;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMAxHEalth(maxHealth);
    }

    public void PlayerTakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("PlayerHurt");
        cameraDMGShake.Shake(ShakePreset);
        Debug.Log("Player Took Hit");
        if (currentHealth <= 0){
            animator.SetTrigger("PlayerHurt");
            PlayerDied();
        }
    }
    void PlayerDied(){
        IsplayerDead = true;
        PauseMenu.instance.DieScreen();
        Debug.Log("Player Died!");
    }



}
