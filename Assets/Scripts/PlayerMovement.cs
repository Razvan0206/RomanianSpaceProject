using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float fowardforce;
    public Transform tr;
    public float scalex;


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
        scalex = fowardforce / 40400 + 1;
        tr.localScale = new Vector3(scalex, 1, 1);


    }

}