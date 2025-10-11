using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameObject[] aiCount;
    // Start is called before the first frame update

    private void Awake()
    {
        CheckGameController();
    }

    void Update()
    {
         GameObject[] aiCount = GameObject.FindGameObjectsWithTag("AI");
    }




    // Update is called once per frame
    void CheckGameController()
    {

        GameObject[] gameControllers = GameObject.FindGameObjectsWithTag("GameController");

        if (gameControllers.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}

