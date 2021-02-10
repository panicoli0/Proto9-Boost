using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Oscilator : MonoBehaviour
{
    [SerializeField] float period = 2f;
    

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [Range(0, 1)] [SerializeField] float movementFactor;

    Vector3 startingPos;


    // Start is called before the first frame update
    void Start()
    {
        // guardarse la posicion inicial en Y de el gameObject
        startingPos = transform.position;


    }

    // Update is called once per frame
    void Update()
    {

        if(period <= Mathf.Epsilon)
        {
            return;
        }

        float cycles = Time.time / period; //grows continually from 0

        const float tau = Mathf.PI * 2f; //about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // va de -1 a +1

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset =  movementFactor * movementVector;
        transform.position = startingPos + offset;
        //randomValue = Random.Range(0, 1.0f) * Time.deltaTime;
        //transform.Translate(Vector3.up * movementFactor * startingPos.y);

    }
    
}
