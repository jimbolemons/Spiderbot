using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
     Rigidbody2D m_Rigidbody;
    void Start()
    {
         m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate((transform.right * speed * Time.deltaTime));
       //m_Rigidbody.AddForce(transform.right * speed);
        
        transform.localPosition += transform.right * speed * Time.deltaTime;
    }
}
