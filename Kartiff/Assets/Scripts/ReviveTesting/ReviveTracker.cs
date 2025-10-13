using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveTracker : MonoBehaviour
{
    public GameObject sideColliders;

    public List<Transform> waypointContainer;

    private TrackParent trackParent;

    // Start is called before the first frame update
    void Start()
    {
        trackParent = sideColliders.GetComponent<TrackParent>();

        waypointContainer = GameObject.Find("AIWaypoints").GetComponent<WaypointContainer>().waypoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(transform.position.x, (sideColliders.transform.position.y + 10), trackParent.playerPosition.z);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            if (other.gameObject.name == "AI")
            {
                foreach (Transform t in waypointContainer)
                {
                    float dist = Vector3.Distance(t.position, other.transform.position);

                    if (dist < other.gameObject.GetComponent<AIDriver>().waypointRange)
                    {
                        other.gameObject.GetComponent<AIDriver>().currentWaypoint = waypointContainer.IndexOf(t);
                    }
                }

                other.gameObject.GetComponent<CarDriver>().enabled = true;
                
            }
        }
    }
}
