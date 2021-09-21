using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
     Rigidbody2D m_Rigidbody;

     public float timer;
     private bool hit = false;
     public ParticleSystem shellExplotion;
     public SpriteRenderer renderers;
     public GameObject bullet;
    void Start()
    {
         m_Rigidbody = GetComponent<Rigidbody2D>();
         bullet = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate((transform.right * speed * Time.deltaTime));
       //m_Rigidbody.AddForce(transform.right * speed);
        if(!hit)
        transform.localPosition += transform.right * speed * Time.deltaTime;
        
        

        timer += Time.deltaTime;
        if (timer > 1)
        {
            Destroy(this.gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        
           
        speed =0;
        Debug.Log("i hit something bra");
        Debug.Log(other.gameObject);
        hit = true;
        //shellExplotion.Play();
        //renderers.enabled = false;
         Destroy(this.gameObject, 5f);
        

    }
}
