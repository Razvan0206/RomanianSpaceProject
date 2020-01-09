using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifeDuration = 2f;

    private float lifeTimer;
    public Rigidbody rb;
    private void Start()
    {
        lifeTimer = lifeDuration;
    }
    void Update()
    {
        rb.AddForce(transform.forward * speed * Time.deltaTime);
       
    }
}
