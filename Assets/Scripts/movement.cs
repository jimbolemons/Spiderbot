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

public float speed2 = 1.0f; //how fast it shakes
public float amount = 1.0f; //how much it shakes
float tiltAroundZ;
float storage;
bool firstgo = true;
bool barelRot = true;
public bool GunMouse;
public bool GunMouse2;
 public Vector3 pos;
         public Vector2 dir;
         public Transform player;
 
         public int maxAngle;
         public int minAngle;
 
         public int angle;
 

float Angle;
public float maxA;
public float minA;
public GameObject pew;
public Transform barrel;
public GameObject recoil;
public ParticleSystem blast;

float store;
 void start()
 {
      
     player = transform.parent;
 
     Angle = 0;
 }
 
void Update() {
        


             
if (isLegs)
{

     //x = 50 max
     //x = -80 min
          float x =  Mathf.Sin(Time.time * speed2) * (amount * Time.deltaTime);
          obj.transform.position += new Vector3(0,x,0);

          
            move = Input.GetAxis("Horizontal");
            if(this.transform.position.x < -80)
            {
                 move =  1 * (7 * Time.deltaTime); 
                 
            } 
            else if(this.transform.position.x > 50)
            {
            move =  -1 * (7 * Time.deltaTime);
            }
            else
            {
                 move =  move * (7 * Time.deltaTime);
            }
            
                    
            moveV = Input.GetAxis("Vertical");
            moveV = moveV *  (7*Time.deltaTime);

            

            if (obj.transform.position.y <= -2.5) 
            {
               moveV += 7* Time.deltaTime;
               //moveV = -moveV;
               
            }
            
             if (obj.transform.position.y >= .116) 
             {
                  moveV -= 7* Time.deltaTime ;
                 // moveV = -moveV;
                 
             }       
             //Debug.Log(obj.transform.position.y);

             obj.transform.position += new Vector3(move ,moveV,0);


               if (Legforward)
               {

                    rLeg1.transform.position = Vector3.Lerp(rLeg1.transform.position, (rLeg1.transform.position += new Vector3(3,0,0)), times );
                         
                         times += Time.deltaTime;
                         if(times >= 1){
                         Legforward = false;
                         times = 0;
                         }
                    

               }

if( Input.GetAxis("Horizontal") >.1 || Input.GetAxis("Horizontal") < -.1){

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
}


          
          rLeg1.transform.position = Vector3.MoveTowards(rLeg1.transform.position,FRTarget.transform.position, 30 * Time.deltaTime);    
          rLeg2.transform.position = Vector3.MoveTowards(rLeg2.transform.position,BRTarget.transform.position, 30 * Time.deltaTime);  
          lLeg1.transform.position = Vector3.MoveTowards(lLeg1.transform.position,FLTarget.transform.position, 30 * Time.deltaTime);  
          lLeg2.transform.position = Vector3.MoveTowards(lLeg2.transform.position,BLTarget.transform.position, 30 * Time.deltaTime);  




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

if (GunMouse)
{
Vector3 mousePositiion = Input.mousePosition;
mousePositiion = Camera.main.ScreenToWorldPoint(mousePositiion);

Vector2 dir = new Vector2(

     mousePositiion.x - transform.position.x,
     mousePositiion.y - transform.position.y
);

transform.right = dir;



//store = Mathf.Clamp(transform.right.y, -.5f, .5f);

//if (transform.right.y >= .5f)
//{
 //    transform.right = new Vector3(dir.x,.5f,0);
//}
//if (transform.right.y <= -.5f)
//{/
   //  transform.right = new Vector3(dir.x,-.5f,0);
//}
Debug.Log(transform.right);


//transform.right = new Vector3(transform.right.x,store,0);


//Angle = Mathf.RoundToInt(Mathf.Atan2(mousePositiion.y, mousePositiion.x) * Mathf.Rad2Deg);
//Angle = this.transform.rotation.z * Mathf.Rad2Deg;


//Angle = Mathf.Clamp(Angle, minA, maxA); 
//transform.localRotation = Quaternion.Euler(0f, 0f, Angle);

}
if(GunMouse2)
{
    pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
             dir = pos - transform.position;
             dir.Normalize();
 
            // if (player.localScale.x == -1)
             //{
            //     dir.x *= -1;
            // }
 
             angle = Mathf.RoundToInt(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
             angle = Mathf.Clamp(angle, minAngle, maxAngle);
             transform.localRotation = Quaternion.Euler(0f, 0f, angle +270 );


             if(recoil.transform.localPosition.x < 1.117768f)
               {
             recoil.transform.localPosition += new Vector3(1* Time.deltaTime,0,0);
               }
               else
               {
                    
             if (Input.GetMouseButtonDown(0)){
               //Debug.Log("pew");
               recoil.transform.localPosition += new Vector3(-.25f,0,0);
               Bullet();
               blast.Play();


             }
               }
           
}


if(isGun)
{


    float smooth = 5.0f;
    float tiltAngle = 10.0f;
  

    // tiltAroundZ += Input.GetAxis("Vertical") * tiltAngle;
    //tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;

 
          if(Input.GetAxis("Vertical") >.01f || Input.GetAxis("Vertical") < -.01f)
          {
               if(firstgo)
               {
                    storage = tiltAroundZ;
                    firstgo = false;
               }
              
                
               tiltAroundZ = storage + Input.GetAxis("Vertical") * tiltAngle;

          }else{
               storage = tiltAroundZ;

          }

           if(Input.GetKey("q")&& tiltAroundZ !> -26)
            {
                tiltAroundZ += -.02f * tiltAngle;
            }
            if(Input.GetKey("e") && tiltAroundZ !< 30)
            {
                tiltAroundZ += .02f * tiltAngle;
            }

            Quaternion target = Quaternion.Euler(0, 0, -tiltAroundZ);

this.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
     Debug.Log(tiltAroundZ);
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
     public void Bullet()
     {
         Instantiate(pew, barrel.position,barrel.rotation);
     }

     
 }
 