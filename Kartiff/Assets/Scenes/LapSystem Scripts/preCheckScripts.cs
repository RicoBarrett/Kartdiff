using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class checkScripts : MonoBehaviour
{

    public Collider preCheckCollider;

    public GameObject player;

    public Collider collisionBox;

    // Start is called before the first frame update
    void Start()
    {
        collisionBox = GameObject.Find("LapCollisionBox").GetComponent<Collider>();

        player = GameObject.Find("Player");

        preCheckCollider = this.GetComponent<Collider>();

        collisionBox.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "AI")
        {
            collisionBox.enabled = true;
        }
    }
}
