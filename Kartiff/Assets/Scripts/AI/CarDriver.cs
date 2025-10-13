using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriver : MonoBehaviour
{
    private float speed = 0f;
    private float turnSpeed = 0f;

    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetInputs(float forwardAmount, float turnAmount)
    {
        speed = forwardAmount * 50f;
        turnSpeed = turnAmount * 100f;
    }

    void Update()
    {
        LimitSpeed();

        //rb.AddForce(transform.forward * speed);
        rb.AddForce(transform.forward * speed, ForceMode.Force);


        //transform.position += transform.forward * speed * Time.deltaTime;
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }

    public float GetSpeed()
    {
        return Mathf.Abs(speed);
    }

    public void ClearTurnSpeed()
    {
        turnSpeed = 0f;
    }

    void LimitSpeed()
    {
        // makes sure player doesn't go faster than intended
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
