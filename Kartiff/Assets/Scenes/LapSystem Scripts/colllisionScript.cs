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

    public string textCount;

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
            lapCount++;
            if (lapCount >= 3)
            {

            }
            else
            {
                textCount = lapCount.ToString();
                Debug.Log("Player entered the zone!");
                lapCounter.text = "Laps:" + textCount + "/3";
            }
            
        }
    }
}
