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



           if (rLeg1.transform.position.x <=obj.transform.position.x +5 && rLeg1.transform.position.x >=obj.transform.position.x +2 )
           {
               
           }
           else if(obj.transform.position.x +5 >= rLeg1.transform.position.x )
           {
                rLeg1.transform.position += new Vector3( 3,0,0);               
                //Legforward = true;
                
                //StartCoroutine(MoveLegs(rLeg1,3));
           } 
           else if(obj.transform.position.x +5 <= rLeg1.transform.position.x )
           {
                rLeg1.transform.position += new Vector3( -3,0,0);
           }




           if (rLeg2.transform.position.x <=obj.transform.position.x +5 && rLeg2.transform.position.x >=obj.transform.position.x +2 )
           {
           }
           else if(obj.transform.position.x +5 >= rLeg2.transform.position.x )
           {
                rLeg2.transform.position += new Vector3( 3,0,0);
           } 
           else if(obj.transform.position.x +5 <= rLeg2.transform.position.x )
           {
                rLeg2.transform.position += new Vector3( -3,0,0);
           }




           if (lLeg1.transform.position.x >=obj.transform.position.x -5 && lLeg1.transform.position.x <=obj.transform.position.x -2 )
           {
           }
           else if(obj.transform.position.x -5 >= lLeg1.transform.position.x )
           {
                lLeg1.transform.position += new Vector3( 3,0,0);
           } 
           else if(obj.transform.position.x -5 <= lLeg1.transform.position.x )
           {
                lLeg1.transform.position += new Vector3( -3,0,0);
           }




           if (lLeg2.transform.position.x >=obj.transform.position.x -5 && lLeg2.transform.position.x <=obj.transform.position.x -2 )
           {
           }
           else if(obj.transform.position.x -5 >= lLeg2.transform.position.x )
           {
                lLeg2.transform.position += new Vector3( 3,0,0);
           } 
           else if(obj.transform.position.x -5 <= lLeg2.transform.position.x )
           {
                lLeg2.transform.position += new Vector3( -3,0,0);
           }








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
 