using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    private Rigidbody rb;
    private float xSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(-5f, 0f, 0f), ForceMode.Impulse);
        xSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void OnCollisionEnter(Collision collision)
    {
        BoxCollider bbox = GetComponent<BoxCollider>();

        //thanks to How to Make Games
        //on Youtube
        //credit here: https://www.youtube.com/watch?v=rQOLdZpOUZg
        //displayed how to do ball physics for 2d Pong, 
        //changed for 3D Pong
        float dist1 = this.transform.position.y - GameObject.Find("Left Player").transform.position.y;
        float dist2 = this.transform.position.y - GameObject.Find("Right Player").transform.position.y;

        //for increasing ball speed
        xSpeed = xSpeed + 0.5f;
        if(collision.gameObject.name == "Left Player")
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(xSpeed, dist1, 0f);
        }
        if(collision.gameObject.name == "Right Player")
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(-xSpeed, dist2, 0f);
        }


    }
}
