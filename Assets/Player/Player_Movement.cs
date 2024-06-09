using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Movement : MonoBehaviour
{
    public static bool win = false;
    Animator animator;
    Rigidbody2D body;
    float speed=10f;
    bool can_jump=true;
    bool jump=false;
    float hor_dir=0f;
    BoxCollider2D box_collider;
    public LayerMask groundLayer;
    public LayerMask Enemy;
    bool insi=false;
    void Awake(){
        body=GetComponent<Rigidbody2D>();
        box_collider=GetComponent<BoxCollider2D>();
        animator=GetComponent<Animator>();
    }
    void FixedUpdate()
    {   
        if(insi){
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime>5f){
                SceneManager.LoadScene(0);
            }
            
        }
        else{
        RaycastHit2D death_ray=Physics2D.BoxCast(box_collider.bounds.center,box_collider.bounds.size,0,Vector2.down,0f,Enemy);
        if(death_ray) death();
        hor_dir=Input.GetAxis("Horizontal");
        body.velocity = new Vector2(hor_dir*speed,body.velocity.y);
        if(body.velocity==new Vector2(0f,0f)){
            animator.Play("idle");
        }else{
            if(hor_dir>0.01f) transform.localScale=new Vector3(10,10,10);
            else if(hor_dir<-0.01f) transform.localScale=new Vector3(-10,10,10);
             if(body.velocity.y==0f) animator.Play("Running");

        }
        if(body.velocity.y>1f) animator.Play("Jump");
        else if(body.velocity.y<-1f) animator.Play("Fall");
        if(can_jump) jump=(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W));
        else{
             can_jump = isGrounded();
        }
        if(jump){
            body.velocity = new Vector2(body.velocity.x,15f);
            jump=false;
            can_jump=false;
        }
        }
    }
    

    bool isGrounded(){
        RaycastHit2D raycast=Physics2D.BoxCast(box_collider.bounds.center,box_collider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        if(raycast) return true;
        else return false; 
    }
    void death(){
        if(!insi && !win){
            animator.Play("Death");
            insi=true;
        }
    }
}
