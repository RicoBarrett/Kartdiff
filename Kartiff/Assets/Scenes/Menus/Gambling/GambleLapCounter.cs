using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GambleLapCounter : MonoBehaviour
{
    public int LapCounter = 0;
    public string Colour;
    public TMP_Text Winner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lap")
        {
            LapCounter++;

            if (LapCounter == 1)
            {
                Time.timeScale = 0;

                Winner.text = GetComponent<NameContainer>().carName;
            }
        }
    }
}
