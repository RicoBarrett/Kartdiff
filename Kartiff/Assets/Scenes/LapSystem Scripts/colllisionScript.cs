using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class colllisionScript : MonoBehaviour
{
    private TextMeshProUGUI lapCounter;

    public Collider collisionBox;

    public GameObject player;

    public int lapCount;

    // Start is called before the first frame update
    void Start()
    {
        collisionBox = this.GetComponent<Collider>();

        player = GameObject.Find("Player");

        lapCounter = GameObject.Find("ScoreCounter").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the zone!");
        }
    }
}
