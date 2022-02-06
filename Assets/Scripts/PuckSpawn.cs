using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckSpawn : MonoBehaviour
{
    public GameObject puck;
    public Transform[] spawnTransform;

    //spawn a puck
    public void SpawnPuck(int direction)
    {
        Transform transform = spawnTransform[0];
        GameObject instance = Instantiate(puck);
        instance.transform.position = transform.position;
        
        Rigidbody rb = instance.GetComponent<Rigidbody>();

        //give the puck a starting force
        //0 out the movement
        rb.AddForce(new Vector3(5f, 0f, 0f), ForceMode.Impulse);

        //the direction is 1 or -1 for left or right movement
        rb.AddForce(new Vector3(5f * direction, 0f, 0f), ForceMode.Impulse);
    }
}
