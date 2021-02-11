using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{  //Variables
     public float speed = 6.0F;
     
   
     private Vector3 moveDirection = Vector3.zero;
     private float move;
     private float moveV;
     private float moveG;
     public bool isLegs = false;
     public bool isGun = false;
 
 
     void Update() {
        


             
if (isLegs)
{
            move = Input.GetAxis("Horizontal");
            move = move / 10f;
            moveV = Input.GetAxis("Vertical");
            moveV = moveV / 20f;             
             this.transform.position += new Vector3(move,moveV,0);

}
             //-60 to -120 degreees
if(isGun)
{
    float smooth = 5.0f;
    float tiltAngle = 10.0f;

    float tiltAroundZ = Input.GetAxis("Vertical") * tiltAngle;
    //tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;

 Quaternion target = Quaternion.Euler(0, 0, -tiltAroundZ);

this.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
}

         
        
     }
 }
 