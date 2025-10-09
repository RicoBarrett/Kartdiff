using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDriver : MonoBehaviour
{
    public float reachedTargetDistance = 5f;
    public float reverseDistance = 10f;

    public WaypointContainer waypointContainer;
    public List<Transform> waypoints;
    public Transform waypoint;
    public int currentWaypoint;
    public float waypointRange;

    private CarDriver carDriver;
    private Vector3 targetPosition;
    private Rigidbody rb;
    private Vector3 direction;
    

    void Start()
    {


        rb = GetComponent<Rigidbody>();

        carDriver = GetComponent<CarDriver>();

        waypoints = waypointContainer.waypoints;
        currentWaypoint = 0;

        waypoint = waypoints[currentWaypoint].GetChild(Random.Range(0, 4));
    }

    void Update()
    {
        if (Vector3.Distance(waypoints[currentWaypoint].position, transform.position) < waypointRange)
        {
            currentWaypoint++;
            waypoint = waypoints[currentWaypoint].GetChild(Random.Range(0, 4));

            if (currentWaypoint == (waypoints.Count-1))
            {
                currentWaypoint = 0;
                waypoint = waypoints[currentWaypoint].GetChild(Random.Range(0, 4));
            }
        }

        targetPosition = waypoint.position;
        float forwardAmount = 0f;
        float turnAmount = 0f;

        // Direction and distance to target
        Vector3 dirToTarget = (targetPosition - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        // Dot product to determine if target is in front or behind
        float dot = Vector3.Dot(transform.forward, dirToTarget);
        float angleToTarget = Vector3.SignedAngle(transform.forward, dirToTarget, Vector3.up);

        if (distanceToTarget > reachedTargetDistance)
        {
            forwardAmount = 1f; // Move forward

            // Turn based on angle to target
            turnAmount = Mathf.Clamp(angleToTarget / 45f, -1f, 1f);
        }
        else
        {
            // Target reached, stop the car
            forwardAmount = 0f;
            carDriver.ClearTurnSpeed();
        }

        // Pass the inputs to the car driver
        carDriver.SetInputs(forwardAmount, turnAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            direction = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);
        }
    }
}
