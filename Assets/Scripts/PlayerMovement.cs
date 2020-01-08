using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float fowardforce;
    public float leftforce;
    public float rightforce;
    float timer1 = 0.0f;
    float timer2 = 0.0f;
    public Transform tr;
    public float CameraMovement;
    public Transform camera1;
    public FixedJoystick variableJoystick;

    void FixedUpdate()
    {
        timer1 -= Time.deltaTime;
        if(timer1 < 0f)
        {
            timer1 = 0f;
        }
        timer2 -= Time.deltaTime;
        if(timer2 < 0f)
        {
            timer2 = 0f;
        }
        if (fowardforce > 0)
        {
            fowardforce -= 10000 * Time.deltaTime;
        }
        if (fowardforce < 0)
        {
            fowardforce = 0;
        }
        if (fowardforce > 40000)
        {
            fowardforce = 40000;
        }
        
        rb.AddForce(transform.forward * fowardforce * Time.deltaTime);
        rb.AddForce(transform.right * -leftforce * Time.deltaTime);
        rb.AddForce(transform.right * rightforce * Time.deltaTime);
        if (variableJoystick.Horizontal != 0 && variableJoystick.Vertical != 0)
        {
            fowardforce += 20000 * Time.deltaTime;
        }
        
        //left
        
        if (leftforce < 0)
        {
            leftforce = 0;
        }
        if (leftforce > 160000)
        {
            leftforce = 160000;
        }
        if(timer1 != 0f)
        {
            leftforce += 160000 * Time.deltaTime;
           
        }
        if(timer1 <= 0)
        {
            leftforce = 0;
        }
        //right
        
        if (rightforce < 0)
        {
            rightforce = 0;
        }
        if (rightforce > 160000)
        {
            rightforce = 160000;
        }
        if(timer2 != 0f)
        {
            rightforce += 160000 * Time.deltaTime;
           
        }
        if(timer2 <= 0)
        {
            rightforce = 0;
        }
        
        


    }
    public void left()
    {       
        timer1 = 2f;
    }
    public void right()
    {
        timer2 = 2f;
    }

}