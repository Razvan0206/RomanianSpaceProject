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
    

    void FixedUpdate()
    {
        if (fowardforce > 0)
        {
            fowardforce -= 8000 * Time.deltaTime;
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
        if (Input.GetKey(KeyCode.W))
        {
            fowardforce += 20000 * Time.deltaTime;

        }

        
        


    }

}