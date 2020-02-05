using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject ShieldGameObject;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {   
            Destroy(other.gameObject);

        }


    }
    public void Down()
    {
        ShieldGameObject.SetActive(true);

    }
    public void Up()
    {
        ShieldGameObject.SetActive(false);

    }
}
