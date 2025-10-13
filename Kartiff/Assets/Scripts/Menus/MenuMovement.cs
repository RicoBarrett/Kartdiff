using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    public int cameraPosition;
    public List<Transform> cameraPositions;
    public GameObject AI;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(IncreaseCameraPosition), 6.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseCameraPosition()
    {
        cameraPosition++;

        if (cameraPosition > 4)
        {
            cameraPosition = 0;
        }


        transform.position = cameraPositions[cameraPosition].position;
        transform.rotation = cameraPositions[cameraPosition].rotation;

    }
}
