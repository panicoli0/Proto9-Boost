using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public Rigidbody rocketRb;
    public float thrust;
    private AudioSource rocketSound;

    // Start is called before the first frame update
    void Start()
    {
        rocketRb = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Thrust();
    }

    private void Rotate()
    {
        

        if (Input.GetKey(KeyCode.A))
        {
            print("moving left");
            transform.Rotate(Vector3.forward);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("moving Right");
            transform.Rotate(-Vector3.forward);
        }
    }

    private void Thrust()
    {
        rocketRb.freezeRotation = true;

        if (Input.GetKey(KeyCode.Space))
        {
            print("Space Bar precced");
            rocketRb.AddRelativeForce(Vector3.up * thrust);
            if (!rocketSound.isPlaying)
            {
                rocketSound.Play();
            }

        }
        else
        {
            rocketSound.Stop();
        }

        rocketRb.freezeRotation = false;
    }
}
