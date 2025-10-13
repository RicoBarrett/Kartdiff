using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    /*
    public float acceleration = 500f;
    public float breakingForce = 300f;
    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    public float maxTurnAngle = 15f;
    private float currentTurnAngle = 0f;*/

    public float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { //movement
        if (Input.GetButton("Horizontal"))
        {
            transform.localPosition += Input.GetAxis("Horizontal") * transform.right * Time.deltaTime * moveSpeed;
        }

        if (Input.GetButton("Vertical"))
        {
            transform.localPosition += Input.GetAxis("Vertical") * transform.forward * Time.deltaTime * moveSpeed;
        }


        /*
        // accelleration
        currentAcceleration = acceleration * Input.GetAxis("Vertical");


        // give the break value when pressign space
        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        */






    }
}
