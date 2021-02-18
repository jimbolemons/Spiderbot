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
     public Transform rLeg1;
     public Vector3 temp;
     bool Legforward = false;

     float times = 0;

     public Transform FRTarget;
     public Transform FLTarget;
     public Transform BRTarget;
     public Transform BLTarget;


public Transform rLeg2;
public Transform lLeg1;
public Transform lLeg2;
public Transform obj;

 
 
void Update() {
        


             
if (isLegs)
{
            move = Input.GetAxis("Horizontal");
            move = move / 20f;    
                    
            moveV = Input.GetAxis("Vertical");
            moveV = moveV / 20f;

            if (obj.transform.position.y <= -2.5) 
            {
               moveV += 20* Time.deltaTime;
            }
            
             if (obj.transform.position.y >= .116) 
             {
                  moveV -= 20* Time.deltaTime ;
             }
             Debug.Log(obj.transform.position.y);

             obj.transform.position += new Vector3(move,moveV,0);


               if (Legforward)
               {

                    rLeg1.transform.position = Vector3.Lerp(rLeg1.transform.position, (rLeg1.transform.position += new Vector3(3,0,0)), times );
                         
                         times += Time.deltaTime;
                         if(times >= 1){
                         Legforward = false;
                         times = 0;
                         }
                    

               }



           if (FRTarget.transform.position.x <=obj.transform.position.x +5 && FRTarget.transform.position.x >=obj.transform.position.x +2 )
           {
               
           }
           else if(obj.transform.position.x +5 >= FRTarget.transform.position.x )
           {
                FRTarget.transform.position += new Vector3( 3,0,0);               
               
           } 
           else if(obj.transform.position.x +5 <= FRTarget.transform.position.x )
           {
                FRTarget.transform.position += new Vector3( -3,0,0);
           }




           if (BRTarget.transform.position.x <=obj.transform.position.x +5 && BRTarget.transform.position.x >=obj.transform.position.x +2 )
           {
           }
           else if(obj.transform.position.x +5 >= BRTarget.transform.position.x )
           {
                BRTarget.transform.position += new Vector3( 3,0,0);
           } 
           else if(obj.transform.position.x +5 <= BRTarget.transform.position.x )
           {
                BRTarget.transform.position += new Vector3( -3,0,0);
           }




           if (FLTarget.transform.position.x >=obj.transform.position.x -5 && FLTarget.transform.position.x <=obj.transform.position.x -2 )
           {
           }
           else if(obj.transform.position.x -5 >= FLTarget.transform.position.x )
           {
                FLTarget.transform.position += new Vector3( 3,0,0);
           } 
           else if(obj.transform.position.x -5 <= FLTarget.transform.position.x )
           {
                FLTarget.transform.position += new Vector3( -3,0,0);
           }




           if (BLTarget.transform.position.x >=obj.transform.position.x -5 && BLTarget.transform.position.x <=obj.transform.position.x -2 )
           {
           }
           else if(obj.transform.position.x -5 >= BLTarget.transform.position.x )
           {
                BLTarget.transform.position += new Vector3( 3,0,0);
           } 
           else if(obj.transform.position.x -5 <= BLTarget.transform.position.x )
           {
                BLTarget.transform.position += new Vector3( -3,0,0);
           }


          
          rLeg1.transform.position = Vector3.MoveTowards(rLeg1.transform.position,FRTarget.transform.position, 20 * Time.deltaTime);    
          rLeg2.transform.position = Vector3.MoveTowards(rLeg2.transform.position,BRTarget.transform.position, 20 * Time.deltaTime);  
          lLeg1.transform.position = Vector3.MoveTowards(lLeg1.transform.position,FLTarget.transform.position, 20 * Time.deltaTime);  
          lLeg2.transform.position = Vector3.MoveTowards(lLeg2.transform.position,BLTarget.transform.position, 20 * Time.deltaTime);  




/*
           if(this.transform.position.x +4 >= rLeg2.transform.position.x )
           {
                rLeg2.transform.position += new Vector3( 10 * Time.deltaTime,0,0);
           }
           if(this.transform.position.x -4 >= lLeg1.transform.position.x )
           {
                lLeg1.transform.position += new Vector3( 10 * Time.deltaTime,0,0);
           }
           if(this.transform.position.x -4 >= lLeg2.transform.position.x )
           {
                lLeg2.transform.position += new Vector3( 10 * Time.deltaTime,0,0);
           }
*/



          // else if(this.transform.position.x - 3 <= rLeg1.transform.position.x )
           //{
             //   rLeg1.transform.position += new Vector3( -3,0,0);
          // }

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
     public void MoveLeg(Transform leg, Vector3 start, Vector3 end)
     {

                leg.transform.position = Vector3.Lerp(start, end, 5 *Time.deltaTime);
     }

     IEnumerator MoveLegs(Transform leg, float move)
     {
          Vector3 start = leg.transform.position;
          Vector3 end = leg.transform.position + new Vector3( move,0,0);

          while(transform.transform.position.x - end.x >= -.1f || transform.transform.position.x - end.x <= .1f  )
          {
               leg.transform.position = Vector3.MoveTowards(start,end,1);
               //leg.transform.position = Vector3.Lerp(start, end, 5 *Time.deltaTime);

               yield return null;
          }
          yield return null;


     }
 }
 