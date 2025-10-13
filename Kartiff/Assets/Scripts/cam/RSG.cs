using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RSG : MonoBehaviour
{
    public GameObject pauseMenu;
    private float startingTime = 5f;
    float currentTime;

    [SerializeField] Text countdownText;

    void Start()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        currentTime = startingTime;

        Debug.Log("Timer starts at: " + currentTime);
    }

    void Update()
    {
        currentTime -= Time.unscaledDeltaTime; // Changed because i forgot what "pausing" does
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}