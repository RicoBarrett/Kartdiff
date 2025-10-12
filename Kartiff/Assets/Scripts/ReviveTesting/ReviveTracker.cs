using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveTracker : MonoBehaviour
{
    public GameObject sideColliders;

    private TrackParent trackParent;

    // Start is called before the first frame update
    void Start()
    {
        trackParent = sideColliders.GetComponent<TrackParent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(transform.position.x, 10, trackParent.playerPosition.z);
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
