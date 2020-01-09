using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{


    public GameObject BulletPrefab;
    public Transform ShotPos;



    public void shoot()
    {
        
        BulletPrefab.transform.position = ShotPos.transform.position;
        BulletPrefab.transform.eulerAngles = ShotPos.transform.eulerAngles;
        Invoke("ActualShoot", 0f);
    }
    public void ActualShoot()
    {
        GameObject bulletobject = Instantiate(BulletPrefab);
    }



}
