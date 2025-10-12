using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    public Camera mainCamera;
    public Object playerTwo;

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

            Instantiate(playerTwo, new Vector3((transform.position.x-10), -3f, -6.2f), new Quaternion(0f,0f,0f, 0f));
}
    }
}
