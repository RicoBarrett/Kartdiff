using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postCheckScripts : MonoBehaviour
{

    public Collider postCheckCollider;

    public GameObject player;

    public Collider collisionBox;

    // Start is called before the first frame update
    void Start()
    {
        collisionBox = GameObject.Find("LapCollisionBox").GetComponent<Collider>();

        player = GameObject.Find("Player");

        postCheckCollider = this.GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "AI")
        {
            collisionBox.enabled = false;
        }
    }
}
