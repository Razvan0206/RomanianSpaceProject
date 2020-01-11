using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    public GameObject BulletPrefab;
    public Transform ShotPos;



    public void shoot()
    {
        
        BulletPrefab.transform.position = ShotPos.transform.position;
        BulletPrefab.transform.eulerAngles = ShotPos.transform.eulerAngles;
        ActualShoot();
        
    }
    public void ActualShoot()
    {
        GameObject bulletobject = Instantiate(BulletPrefab);
    }
    



}
