using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPotions : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void AIMode()
    {
        SceneManager.LoadScene(2);
    }

    public void Options()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
