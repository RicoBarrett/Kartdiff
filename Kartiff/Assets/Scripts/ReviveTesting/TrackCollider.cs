using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject sideColliders;

    // Start is called before the first frame update
    void Start()
    {
        sideColliders = GameObject.Find("SideCollidersMain");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sideColliders.GetComponent<TrackParent>().playerPosition = other.gameObject.transform.position;

            if (other.gameObject.name == "AI")
            {
                other.gameObject.GetComponent<CarDriver>().enabled = false;
            }
        }
    }
}
