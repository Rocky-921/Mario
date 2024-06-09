using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw_move : MonoBehaviour
{
    bool right=true;
    BoxCollider2D box_collid;
    public LayerMask wall_mask;
    void Awake(){
        box_collid=GetComponent<BoxCollider2D>();
    }
    
    void FixedUpdate()
    {
        if(right) transform.position += new Vector3(0.1f,0,0);
        else transform.position-=new Vector3(0.1f,0,0);
        RaycastHit2D raycast_toLeft=Physics2D.BoxCast(box_collid.bounds.center,box_collid.bounds.size,0,Vector2.right,0.2f,wall_mask);
        if(raycast_toLeft){
            right=false;
            return;
        }

        RaycastHit2D raycast_toRight=Physics2D.BoxCast(box_collid.bounds.center,box_collid.bounds.size,0,Vector2.left,0.2f,wall_mask);
        if(raycast_toRight) right=true;
    }
}
