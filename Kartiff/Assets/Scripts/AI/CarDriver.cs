using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriver : MonoBehaviour
{
    private float speed = 0f;
    private float turnSpeed = 0f;

    public void SetInputs(float forwardAmount, float turnAmount)
    {
        speed = forwardAmount * 50f;
        turnSpeed = turnAmount * 100f;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
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
}
