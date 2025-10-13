using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerUpUI : MonoBehaviour
{
    [Header("UI Box Reference")]
    [SerializeField] private Image powerUpDisplay;  // Needed to set center for reference to place other powerups

    [Header("Power-Up Sprites")]
    [SerializeField] private Sprite PWRBoost;
    [SerializeField] private Sprite PWRJail;
    [SerializeField] private Sprite PWRTrain;

    private void Start()
    {
        powerUpDisplay.sprite = null;
        powerUpDisplay.enabled = false; // needed to make white ui box dissapear at start of game

    }

    public void SetPowerUpImage(string PowerUpReader)
    {
        switch (PowerUpReader)
        {
            case "Boost":
                powerUpDisplay.sprite = PWRBoost;
                powerUpDisplay.enabled = true;
                Debug.Log("Display Image Boost");
                break;
            case "Jail":
                powerUpDisplay.sprite = PWRJail;
                powerUpDisplay.enabled = true;
                Debug.Log("Display Image Jail");
                break;
            case "Train":
                powerUpDisplay.sprite = PWRTrain;
                powerUpDisplay.enabled = true;
                Debug.Log("Display Image Train");
                break;
        }
    }
    public void ClearPowerUpIcon()
    {
        powerUpDisplay.enabled = false;
        powerUpDisplay.sprite = null;
    }
}
