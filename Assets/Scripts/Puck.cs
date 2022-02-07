using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(-15f, 0f, 0f), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
