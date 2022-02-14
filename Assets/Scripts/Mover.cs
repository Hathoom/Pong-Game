using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public int lrplayer;

    public float movementPerSecond = 5f;

    public bool FreezeY = true;

    private Vector3 m_OriginPos;

    // Start is called before the first frame update
    void Start()
    {
        m_OriginPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementAxis;
        if (lrplayer == 0)
        {
            movementAxis = Input.GetAxis("Player1");
        }
        else
        {
            movementAxis = Input.GetAxis("Player2");
        }
        // Transform transform = GetComponent<Transform>();

        Vector3 force = Vector3.up * movementAxis * movementPerSecond * Time.deltaTime;

        Rigidbody rbody = GetComponent<Rigidbody>();
        if (rbody)
        {
            rbody.AddForce(force, ForceMode.VelocityChange);
        }

        if(movementAxis == 0)
        {
            rbody.velocity = Vector3.zero;  
            rbody.angularVelocity = Vector3.zero;  
            rbody.Sleep();
        }

        Vector3 currentPos = transform.position;

        if (FreezeY)
        {
            currentPos.y = m_OriginPos.y;    
        }

        // transform.position += Vector3.right * movementAxis * movementPerSecond * Time.deltaTime;

        // if (Input.GetKey(KeyCode.A))
        // {
        //     Transform transform = GetComponent<Transform>();
        //     transform.position += -Vector3.right * movementPerSecond * Time.deltaTime;
        // }
        //
        // if (Input.GetKey(KeyCode.D))
        // {
        //     Transform transform = GetComponent<Transform>();
        //     transform.position += Vector3.right * movementPerSecond * Time.deltaTime;
        // }
    }
}
