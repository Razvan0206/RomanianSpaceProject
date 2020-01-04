using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float fowardforce;
    public Transform tr;
    public float CameraMovement;
    public Transform camera1;
    public FixedJoystick variableJoystick;

    void FixedUpdate()
    {
        if (fowardforce > 0)
        {
            fowardforce -= 10000 * Time.deltaTime;
        }
        if (fowardforce > 40000)
        {
            fowardforce = 40000;
        }
        if (fowardforce < 0)
        {
            fowardforce = 0;
        }
        rb.AddForce(transform.forward * fowardforce * Time.deltaTime);
        if (variableJoystick.Horizontal != 0 && variableJoystick.Vertical != 0)
        {
            fowardforce += 20000 * Time.deltaTime;

        }
        
        
        


    }

}