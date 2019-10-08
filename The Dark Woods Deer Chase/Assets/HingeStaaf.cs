using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeStaaf : MonoBehaviour
{


    private Rigidbody2D rb2d;
    //private JointMotor2D motor;
    public float speed = 100f;
    private HingeJoint2D hjstaaf;
    private JointMotor2D motorstaaf;



    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        hjstaaf = GetComponent<HingeJoint2D>();
        
        motorstaaf = hjstaaf.motor;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.rotation.eulerAngles.z);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(transform.rotation.z < 0)
            {
                print("pannekoek");
                motorstaaf.motorSpeed = speed;
                hjstaaf.motor = motorstaaf;
                print(motorstaaf.motorSpeed);
            }
            if (transform.rotation.z > 0)
            {
                print("pannezxczxckoek");
                motorstaaf.motorSpeed = -speed;
                hjstaaf.motor = motorstaaf;
                print(motorstaaf.motorSpeed);
            }
        }
    }
}