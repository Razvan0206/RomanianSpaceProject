using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public Transform tr;
    public float vertical;
    public float orizontal;
    public FixedJoystick variableJoystick;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical += variableJoystick.Vertical * 90 * Time.deltaTime;
        orizontal += variableJoystick.Horizontal * 90 * Time.deltaTime;
        tr.rotation = new Vector3(vertical, orizontal, 0);
        
    }
}
