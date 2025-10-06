using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollection : MonoBehaviour
{

    //[SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PowerUp")
        {
            Debug.Log("Triggered with: ");
            Destroy(collider.gameObject); 
        }
    }
}
