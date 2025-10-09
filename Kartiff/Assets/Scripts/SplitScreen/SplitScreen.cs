using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            mainCamera.GetComponent<Camera>().rect = new Rect(mainCamera.GetComponent<Camera>().rect.x, mainCamera.GetComponent<Camera>().rect.y, 0.5f, 1f);
            secondaryCamera.GetComponent<Camera>().rect = new Rect(secondaryCamera.GetComponent<Camera>().rect.x+0.5f, secondaryCamera.GetComponent<Camera>().rect.y, 0.5f, 1f);
        }
    }
}
