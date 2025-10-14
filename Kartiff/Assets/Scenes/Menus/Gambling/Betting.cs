using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Betting : MonoBehaviour
{
    public TMP_Text RedCarText;
    public TMP_Text WhiteCarText;
    public TMP_Text BlackCarText;
    public TMP_Text BlueCarText;

    public TMP_InputField RedName;
    public TMP_InputField WhiteName;
    public TMP_InputField BlackName;
    public TMP_InputField BlueName;

    public string RedNameString;
    public string WhiteNameString;
    public string BlackNameString;
    public string BlueNameString;

    public Camera cam;

    private int RedCar = 0;
    private int WhiteCar = 0;
    private int BlackCar = 0;
    private int BlueCar = 0;

    public GameObject RedAI;
    public GameObject WhiteAI;
    public GameObject BlackAI;
    public GameObject BlueAI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Red()
    {
        RedCar = RedCar + 100;
        RedCarText.text = RedCar.ToString();
    }

    public void White()
    {
        WhiteCar = WhiteCar + 100;
        WhiteCarText.text = WhiteCar.ToString();
    }

    public void Black()
    {
        BlackCar = BlackCar + 100;
        BlackCarText.text = BlackCar.ToString();
    }

    public void Blue()
    {
        BlueCar = BlueCar + 100;
        BlueCarText.text = BlueCar.ToString();
    }

    public void StartGame()
    {
        Time.timeScale = 1;

        cam.gameObject.SetActive(false);
    }

    public void SetRedName()
    {
        RedNameString = RedName.text;
        RedAI.GetComponent<NameContainer>().carName = RedNameString;
    }

    public void SetWhiteName()
    {
        WhiteNameString = WhiteName.text;
        WhiteAI.GetComponent<NameContainer>().carName = WhiteNameString;
    }

    public void SetBlackName()
    {
        BlackNameString = BlackName.text;
        BlackAI.GetComponent<NameContainer>().carName = BlackNameString;
    }

    public void SetBlueName()
    {
        BlueNameString = BlueName.text;
        BlueAI.GetComponent<NameContainer>().carName = BlueNameString;
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
