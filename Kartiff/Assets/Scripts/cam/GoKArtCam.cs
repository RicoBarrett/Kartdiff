using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoKArtCam : MonoBehaviour
{
    public Transform target;
    public float distance = 6f;
    public float height = 2f;
    public float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 carForward = target.forward;
        Vector3 carUp = Vector3.up;

        Vector3 carPosition = target.position;
        Vector3 behindCar = carPosition - carForward * distance;
        Vector3 aboveBehindCar = behindCar + carUp * height;

        Vector3 currentPosition = transform.position;
        Vector3 newPosition = Vector3.SmoothDamp(currentPosition, aboveBehindCar, ref velocity, smoothTime);

        transform.position = newPosition;
        transform.rotation = Quaternion.LookRotation(carForward, carUp);
    }
}