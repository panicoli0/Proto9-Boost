using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] float mainThrust;
    [SerializeField] float rcsThrust = 100f;

    Rigidbody rocketRb;
    
    AudioSource rocketSound;


    enum State { Alive, Dying, Transcending}
    State state = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        

        rocketRb = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            Rotate();
            Thrust();
        }

        
    }

    void OnCollisionEnter(Collision other)
    {
        
        {
            if (state != State.Alive) { return; } //Ignora collisiones

            switch (other.gameObject.tag)
            {
                case "OK":
                    Debug.Log("Ganastes PAPA");
                    break;

                case "Friendly":
                    //Do nothing
                    Debug.Log("Este es: " + other.gameObject.tag);
                    break;

                case "Finish":
                    //Ganastes
                    state = State.Transcending;
                    Debug.Log("Este es: " + other.gameObject.tag);
                    Invoke("LoadNextLevel", 1f);
                    break;

                default:
                    //Pediste
                    state = State.Dying;
                    Debug.Log("Le pegaste a algo que te mata: " + other.gameObject.tag);
                    Invoke("LoadFirstLevel", 1f);
                    break;
            }
        }

       
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
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
