using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Mov : MonoBehaviour
{
    public Rigidbody2D body;
    void FixedUpdate()
    {
        if(body.transform.position.x<0.0f) transform.position=new Vector3(0,1.2f,-10);
        else if(body.transform.position.x>81f) transform.position=new Vector3(81f,1.2f,-10);
        else transform.position = new Vector3(body.transform.position.x, 1.2f, -10);
    }
}
