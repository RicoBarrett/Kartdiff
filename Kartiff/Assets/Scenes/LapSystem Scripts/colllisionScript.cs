using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class colllisionScript : MonoBehaviour
{
    private TextMeshProUGUI lapCounter;

    public Collider collisionBox;

    //public Collider preCheckCollider;

    public GameObject player;

    public static int playerLapCount;

    public string textPlayerCount;

    public static int AILapCount;

    // Start is called before the first frame update
    void Start()
    {
        collisionBox = this.GetComponent<Collider>();

        player = GameObject.Find("Player");

        lapCounter = GameObject.Find("ScoreCounter").GetComponent<TextMeshProUGUI>();

        //preCheckCollider = GameObject.Find("PreCheckTrigger").GetComponent<Collider>();

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player LapSystem")
        {
            playerLapCount++;

            if (playerLapCount >= 3)
            {
                textPlayerCount = playerLapCount.ToString();
                lapCounter.text = "Laps: 3/3";
            }
            else
            {
                textPlayerCount = playerLapCount.ToString();
                //Debug.Log("Player entered the zone!");
                lapCounter.text = "Laps:" + textPlayerCount + "/3";
            }
            
        }
    }
}
