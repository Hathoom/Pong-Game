using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject[] puck = GameObject.FindGameObjectsWithTag("Puck");
        Puck component = puck[0].GetComponent<Puck>();
        float speed = component.GetxSpeed();

        if (speed < 0)
        {
            speed = speed + 1.0f;
        }
        else
        {
            speed = speed - 1.0f;
        }

        component.SetxSpeed(speed, false);
        component.RotateZ45();
    }
}
