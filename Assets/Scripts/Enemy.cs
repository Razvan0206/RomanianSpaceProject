using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]Transform target;
    
    [SerializeField] float rotationalDamp;
    [SerializeField] float movementSpeed;
    public float distance;
    public GameObject BulletPrefab;
    public Transform ShotPos;
    private int nextUpdate=1;
    void Start()
    {

    }
    void Update()
    {
        var fwd = transform.TransformDirection (Vector3.forward);
        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;
        BulletPrefab.transform.position = ShotPos.transform.position;
        BulletPrefab.transform.eulerAngles = ShotPos.transform.eulerAngles;
        if(Physics.Raycast(transform.position, fwd, out hit, 100f) && hit.transform.tag == "Player")
        {
            if(Time.time>=nextUpdate){ 
             nextUpdate=Mathf.FloorToInt(Time.time)+1;            
             Shoot();
            }   
        }

        
        Turn();
        distance = Vector3.Distance (target.transform.position, transform.position);
        if(distance > 60f)
        {
            Move();
        }
    }
    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);

    }
    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
    void Shoot()
    {
        GameObject bulletobject = Instantiate(BulletPrefab);
    }
}
