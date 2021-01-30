using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public Rigidbody rocketRb;
    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        rocketRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Space Bar precced");
            rocketRb.AddRelativeForce(Vector3.up * thrust);
        }

        if (Input.GetKey(KeyCode.A))
        {
            print("moving left");
            transform.Rotate(Vector3.forward);

        } else if (Input.GetKey(KeyCode.D))
        {
            print("moving Right");
            transform.Rotate(-Vector3.forward);
        }
    }
}
