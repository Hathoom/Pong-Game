using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    private Rigidbody rb;
    private float xSpeed;

    public AudioClip slowsound;
    public AudioClip fastsound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(-5f, 0f, 0f), ForceMode.Impulse);
        xSpeed = -5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        BoxCollider bbox = GetComponent<BoxCollider>();

        //sound stuff
        AudioSource audioSource = GetComponent<AudioSource>();
        if (xSpeed > -10 && xSpeed < 10)
        {
            audioSource.clip = slowsound;
        }
        else
        {
            audioSource.clip = fastsound;
        }

        audioSource.Play();

        //thanks to How to Make Games
        //on Youtube
        //credit here: https://www.youtube.com/watch?v=rQOLdZpOUZg
        //displayed how to do ball physics for 2d Pong, 
        //changed for 3D Pong
        float dist1 = this.transform.position.y - GameObject.Find("Left Player").transform.position.y;
        float dist2 = this.transform.position.y - GameObject.Find("Right Player").transform.position.y;

        //for increasing ball speed
        if(collision.gameObject.name == "Left Player")
        {
            xSpeed = xSpeed * -1;
            this.GetComponent<Rigidbody>().velocity = new Vector3(xSpeed, dist1, 0f);
            xSpeed = xSpeed + 0.5f;
        }
        if(collision.gameObject.name == "Right Player")
        {
            xSpeed = xSpeed * -1;
            this.GetComponent<Rigidbody>().velocity = new Vector3(xSpeed, dist2, 0f);
            xSpeed = xSpeed - 0.5f;
        }
    }

    public float GetxSpeed()
    {
        return xSpeed;
    }

    public void SetxSpeed(float newSpeed, bool fast)
    {
        float xForce;

        //going left, negative x, or slow down going right
        if (xSpeed < 0 || (!fast && xSpeed > 0))
        {
            xForce = -1.0f;
        }
        // going right, positive x
        else
        {
            xForce = 1.0f;
        }
        xSpeed = newSpeed;
        Vector3 force = new Vector3(xForce, 0, 0);
        this.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    public void RotateZ45()
    {
        this.transform.Rotate(0, 0, this.transform.rotation.z + 45);
    }
}
