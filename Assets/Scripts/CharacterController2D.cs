using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public Animator animator;
    
    public float MovementSpeed = 0.5f;
    public float JumpForce = 0.5f;
    private Rigidbody2D _rigidbody;
    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();   
    }
    private void Flip(){
        transform.localScale = Vector3.one;
    }
    private void UnFlip(){
        transform.localScale = new Vector3(-1,1,1);
    }
    private void Update() 
    {
        //reseting jumping animation
        animator.SetBool("IsJumping", false);

        //movement
        var movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement));
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;

        //jumping
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        // swap sprite direction, if going left or roght
        if (movement > 0){
            Flip();
            
        }
        else if (movement < 0){
            UnFlip();
        }
    }

    public void Jump(){
        if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f){                
            
        _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        animator.SetBool("IsJumping", true);
        }
        
    } 
    
         

    
}
