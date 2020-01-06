using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{


    public GameObject BulletPrefab;
    public Transform ShotPos;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletobject = Instantiate(BulletPrefab);
            bulletobject.transform.position = ShotPos.transform.position;
            bulletobject.transform.position = ShotPos.transform.forward;
        }
    }




}
