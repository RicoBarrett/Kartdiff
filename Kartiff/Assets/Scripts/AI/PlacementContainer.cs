using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementContainer : MonoBehaviour
{
    public List<Transform> placements;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform tr in gameObject.GetComponentInChildren<Transform>())
        {
            placements.Add(tr);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}