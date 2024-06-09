using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject paus;
    void FixedUpdate(){
        if(Input.GetKey(KeyCode.Escape)){    
            Time.timeScale=0f;
            paus.SetActive(true);
        }
    }
    public void resume(){
        Time.timeScale=1f;
        gameObject.SetActive(false);
    }
    public void restart(){
        Time.timeScale=1f;
        SceneManager.LoadScene(1);
    }
    public void quit(){
        Application.Quit();
    }
}
