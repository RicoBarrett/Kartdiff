using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceSystem : MonoBehaviour
{

    private TextMeshProUGUI placeCounter;

    public GameObject player;
    public GameObject[] aiCount;
    public GameObject Waypoint;
    public GameObject gameController;
    public int AICount;
    public int posFinder;
    public float[] aiDistance;
    public int aiAmount;

    public float playerDistance;
    public int playerPos;

    // Start is called before the first frame update
    void Start()
    {
        aiCount = GameObject.FindGameObjectsWithTag("AI");

        Debug.Log(aiCount.Length);

        aiAmount = aiCount.Length;

        aiDistance = new float[aiAmount];

        player = GameObject.Find("Player");

        Waypoint = GameObject.Find("WaypointOne");

        placeCounter = GameObject.Find("PlaceCounter").GetComponent<TextMeshProUGUI>();

        gameController = this.GetComponent<GameObject>();

        AICount = 0;
        posFinder = 0;
        playerPos = 4;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(player.transform.position, Waypoint.transform.position);

        while (AICount < aiCount.Length)
        {
            aiDistance[AICount] = Vector3.Distance(aiCount[AICount].transform.position, Waypoint.transform.position);
            AICount++;
        }

        

        placeCounter.text = "Place:" + playerPos;
        AICount = 0;
        posFinder = 0;


    }
}


