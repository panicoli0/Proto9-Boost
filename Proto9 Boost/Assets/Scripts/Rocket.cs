using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float mainThrust;
    [SerializeField] float rcsThrust = 100f;

    Rigidbody rocketRb;
    
    AudioSource rocketSound;

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

    void OnCollisionEnter(Collision other)
    {
        
        {
            switch (other.gameObject.tag)
            {
                case "Friendly":
                    //Do nothing
                    Debug.Log("Este es: " + other.gameObject.tag);
                    break;

                case "Fuel":
                    //Carga de combustible
                    Debug.Log("Este es: " + other.gameObject.tag);
                    break;

                case "OK":
                    //Ganastes
                    Debug.Log("Este es: " + other.gameObject.tag);
                    break;

                default:
                    //Pediste
                    Debug.Log("Este es: " + other.gameObject.tag);
                    break;
            }
        }
        
    }

    private void Rotate()
    {
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            //print("moving left");
            transform.Rotate(Vector3.forward * rotationThisFrame);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            //print("moving Right");
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rocketRb.freezeRotation = false;
    }

    private void Thrust()
    {
        rocketRb.freezeRotation = true;

        if (Input.GetKey(KeyCode.Space))
        {
            //print("Space Bar precced");
            rocketRb.AddRelativeForce(Vector3.up * mainThrust);
            if (!rocketSound.isPlaying)
            {
                rocketSound.Play();
            }

        }
        else
        {
            rocketSound.Stop();
        }

        
    }
}
