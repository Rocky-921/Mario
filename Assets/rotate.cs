using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    bool to_right = true;
    void FixedUpdate()
    {
        if(transform.rotation.z>0.4) to_right=false;
        if(transform.rotation.z<-0.4) to_right=true;
        if(to_right) transform.Rotate(new Vector3(0,0,1f));
        else transform.Rotate(new Vector3(0,0,-1f));
    }
}
