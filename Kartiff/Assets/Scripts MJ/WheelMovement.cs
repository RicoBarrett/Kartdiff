using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WheelMovement : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;


    public InputAction playerControls;

    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    private void OnEnable()
    {
        
        if (playerControls != null)
            playerControls.Enable();
    }

    private void OnDisable()
    {
        if (playerControls != null)
            playerControls.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = Vector2.zero;

        
        if (playerControls != null)
        {
           
            moveInput = playerControls.ReadValue<Vector2>();
        }

        
        currentAcceleration = acceleration * moveInput.y;
        currentTurnAngle = maxTurnAngle * moveInput.x;

        
        if (Keyboard.current != null && Keyboard.current.spaceKey.isPressed)
            currentBreakingForce = breakingForce;
        else
            currentBreakingForce = 0f;

        
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakingForce;
        frontLeft.brakeTorque = currentBreakingForce;
        backRight.brakeTorque = currentBreakingForce;
        backLeft.brakeTorque = currentBreakingForce;

        frontRight.steerAngle = currentTurnAngle;
        frontLeft.steerAngle = currentTurnAngle;
    }
}



