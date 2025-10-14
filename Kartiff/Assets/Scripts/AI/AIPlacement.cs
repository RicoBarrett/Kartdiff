using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlacement : MonoBehaviour
{
    public float waypointDist;

    public float placementRange = 280f;
    public int currentPlacement;
    public PlacementContainer placementContainer;
    public List<Transform> placements;
    public Transform placement;

    public GameObject GameController;
    public List<float> rank;
    public int place;

    // Start is called before the first frame update
    void Start()
    {
        rank = GameController.GetComponent<Placement>().ranks;

        placements = placementContainer.placements;
        currentPlacement = 0;

        placement = placements[currentPlacement];
    }

    // Update is called once per frame
    void Update()
    {
        waypointDist = Vector3.Distance(placements[currentPlacement].position, transform.position);

        if (Vector3.Distance(placements[currentPlacement].position, transform.position) < placementRange)
        {
            currentPlacement++;
            placement = placements[currentPlacement];

            if (currentPlacement == (placements.Count - 1))
            {
                currentPlacement = 0;
                placement = placements[currentPlacement];
            }
        }


        Placements();
    }

    public void Placements()
    {
        if (waypointDist == rank[0])
        {
            place = 4;
        }
        if (waypointDist == rank[1])
        {
            place = 3;
        }
        if (waypointDist == rank[2])
        {
            place = 2;
        }
        if (waypointDist == rank[3])
        {
            place = 1;
        }
    }
}
