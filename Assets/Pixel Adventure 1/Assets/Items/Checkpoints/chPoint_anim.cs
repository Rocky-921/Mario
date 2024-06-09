using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chPoint_anim : MonoBehaviour
{
    Animator animator;
    void Awake(){
        animator=GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.name=="Player"){
            animator.SetBool("move",true);
            StartCoroutine(idl());
        }
    }
    IEnumerator idl(){
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("move",false);
    }
}
