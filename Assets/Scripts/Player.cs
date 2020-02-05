using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float fowardforce;
    public float leftforce;
    public float rightforce;
    public int hp = 100;
    float timer1 = 0.0f;
    float timer2 = 0.0f;
    public Transform tr;
    public float CameraMovement;
    public Transform camera1;
    public FixedJoystick variableJoystick;
    public bool go;
    public Text hptext;
    public float maxspeed = 30000;
    bool counter;
    float counterfloat = 10f;
    public ParticleSystem SpeedParticles;

    public Button DashButton;
    
    void Start()
    {
        
        

    }
    void Update()
    {
        
        
        hptext.text = hp.ToString();
        counterfloat += Time.deltaTime;
        if(counterfloat > 10)
        {
            counter = true;
        }
        if(counterfloat < 10)
        {
            counter = false;
        }
        if(counter == true)
        {
            DashButton.interactable = true;

        }
        if(counter == false)
        {
            DashButton.interactable = false;
        }
        if(fowardforce > 30000f)
        {
            
            SpeedParticles.Play();
            
        }
        if(fowardforce < 30000f)
        {    
            
            SpeedParticles.Stop();
            
        }
    }
    void FixedUpdate()
    {
       
        if(Input.GetKeyDown("w"))
        {
            go = true;
        }
        if(Input.GetKeyUp("w"))
        {
            go = false;
        }
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
            fowardforce -= 15000 * Time.deltaTime;
        }
        if (fowardforce < 0)
        {
            fowardforce = 0;
        }
        if (fowardforce > maxspeed)
        {
            fowardforce = maxspeed;
        }
        
        rb.AddForce(transform.forward * fowardforce * Time.deltaTime);
        rb.AddForce(transform.right * -leftforce * Time.deltaTime);
        rb.AddForce(transform.right * rightforce * Time.deltaTime);
        
        if(go == true)
        {
            fowardforce += 25000 * Time.deltaTime;
        }
            
        
        
        //left
        
        if (leftforce < 0)
        {
            leftforce = 0;
        }
        if (leftforce > 50000)
        {
            leftforce = 50000;
        }
        if(timer1 != 0f)
        {
            leftforce += 1000000 * Time.deltaTime;
           
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
        if (rightforce > 50000)
        {
            rightforce = 50000;
        }
        if(timer2 != 0f)
        {
            rightforce += 1000000 * Time.deltaTime;
           
        }
        if(timer2 <= 0)
        {
            rightforce = 0;
        }
        
        


    }
    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Enemy Bullet")
        {
            hp -= 1; 
            Destroy(other.gameObject);          
        }
        

    }
    public void left()
    {       
        timer1 = 1f;
    }
    public void right()
    {
        timer2 = 1f;
    }
    public void Go()
    {  
        go = true;
    }
    public void stop()
    {  
        go = false;
    }
    public void Dash()
    {
        if(counter == true)
        {
            maxspeed = 100000;
            fowardforce += 100000;
            counterfloat = 0;
            Invoke("voidmaxspeed", 2.5f);
        }
        
    }
    void voidmaxspeed()
    {
        maxspeed = 30000;

    }


}