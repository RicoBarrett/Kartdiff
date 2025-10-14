using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public GameObject AIRed;
    public GameObject AIBlue;
    public GameObject AIBlack;
    public GameObject AIWhite;

    public List<float> ranks;

    private AIPlacement aiDriverRed;
    private AIPlacement aiDriverBlue;
    private AIPlacement aiDriverBlack;
    private AIPlacement aiDriverWhite;

    private float distanceRed;
    private float distanceBlue;
    private float distanceBlack;
    private float distanceWhite;

    // Start is called before the first frame update
    void Start()
    {
        aiDriverRed = AIRed.GetComponent<AIPlacement>();
        aiDriverBlue = AIBlue.GetComponent<AIPlacement>();
        aiDriverBlack = AIBlack.GetComponent<AIPlacement>();
        aiDriverWhite = AIWhite.GetComponent<AIPlacement>();

        distanceRed = aiDriverRed.waypointDist;
        distanceBlue = aiDriverBlue.waypointDist;
        distanceBlack = aiDriverBlack.waypointDist;
        distanceWhite = aiDriverWhite.waypointDist;

        ranks.Add(distanceRed);
        ranks.Add(distanceBlue);
        ranks.Add(distanceBlack);
        ranks.Add(distanceWhite);
    }

    // Update is called once per frame
    void Update()
    {
        ranks.Clear();

        distanceRed = aiDriverRed.waypointDist;
        distanceBlue = aiDriverBlue.waypointDist;
        distanceBlack = aiDriverBlack.waypointDist;
        distanceWhite = aiDriverWhite.waypointDist;

        ranks.Add(distanceRed);
        ranks.Add(distanceBlue);
        ranks.Add(distanceBlack);
        ranks.Add(distanceWhite);

        ranks.Sort();
    }
}
