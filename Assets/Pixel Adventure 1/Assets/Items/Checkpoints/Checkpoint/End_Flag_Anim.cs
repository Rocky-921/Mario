using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Flag_Anim : MonoBehaviour
{
    public GameObject pause;
    public GameObject winning;
    Animator animator;
    void Awake(){
        animator=GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.name=="Player"){
            animator.SetBool("move",true);
            Player_Movement.win=true;
            StartCoroutine(Win());
        }
    }
    IEnumerator Win(){
        yield return new WaitForSeconds(3);
        Time.timeScale=0f;
        pause.SetActive(true);
        winning.SetActive(true);
        pause.transform.Find("Resume").gameObject.SetActive(false);
    }
}
