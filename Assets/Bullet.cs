﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifeDuration = 2f;

    private float lifeTimer;


    private void Start()
    {
        lifeTimer = lifeDuration;
    }



    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTimer = -Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}