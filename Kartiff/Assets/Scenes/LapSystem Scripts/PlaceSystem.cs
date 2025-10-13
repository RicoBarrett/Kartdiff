using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlaceSystem : MonoBehaviour
{

    private TextMeshProUGUI placeCounter;

    public GameObject player;
    public GameObject[] aiCount;
    public GameObject  [] Waypoint;
    public GameObject gameController;
    public int AICount;
    public int WaypointCount;
    public int posFinder;
    public float[] aiDistance;
    public float[] placesTracker;
    public int aiAmount;
    public int waypointAmount;
    public float playerDistance;
    public int playerPos;
    

    // Start is called before the first frame update
    void Start()
    {
        aiCount = GameObject.FindGameObjectsWithTag("AI LapSystem");

        Waypoint = GameObject.FindGameObjectsWithTag("Waypoints LapSystem");

        //Debug.Log(aiCount.Length);

        aiAmount = aiCount.Length;
        waypointAmount = Waypoint.Length;

        aiDistance = new float[aiAmount];

        placesTracker = new float[aiAmount + 1];

        player = GameObject.Find("PlayerFixed (1)");

        placeCounter = GameObject.Find("PlaceCounter").GetComponent<TextMeshProUGUI>();

        gameController = this.GetComponent<GameObject>();

        WaypointCount = 0;
        AICount = 0;
        posFinder = 0;
        playerPos = 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        playerDistance = Vector3.Distance(player.transform.position, Waypoint[WaypointCount].transform.position);
        placesTracker[aiAmount] = playerDistance;

        if (playerDistance < 3)
        {
            if (Waypoint[WaypointCount] == Waypoint[waypointAmount - 1])
            {
                WaypointCount = 0;
            }

            else
            {
                WaypointCount++;
            }
        }
        

            while (AICount < aiCount.Length)
            {
                aiDistance[AICount] = Vector3.Distance(aiCount[AICount].transform.position, Waypoint[WaypointCount].transform.position);
                placesTracker[AICount] = Vector3.Distance(aiCount[AICount].transform.position, Waypoint[WaypointCount].transform.position);

                if (aiDistance[AICount] < 3)
                {
                    if (Waypoint[WaypointCount] == Waypoint[waypointAmount - 1])
                    {
                    WaypointCount = 0;
                    }

                    else
                    {
                    WaypointCount++;
                    }
                }

                AICount++;
            }


        Array.Sort(placesTracker);

        while (posFinder < placesTracker.Length)
        {
            //Debug.Log("While loop works!");

            if (placesTracker[posFinder] == playerDistance)
            {
                //Debug.Log("If statement works!");
                playerPos = posFinder + 1;
            }
            posFinder++;
        }
       
        placeCounter.text = "Place:" + playerPos;
        AICount = 0;
        posFinder = 0;


    }
}


