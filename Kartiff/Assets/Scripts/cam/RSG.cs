using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSG : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}