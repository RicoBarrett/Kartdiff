using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public KeyCode useKey = KeyCode.E; // key to use boost
    [SerializeField] private PlayerPowerUpUI powerUpUI; // Displays correct PowerUp Icon

    //Speed Power Up
    [Header("Speed Power Up")]
    [SerializeField] private float boostDuration = 5f; // how long speed boost lasts
    [SerializeField] private float speedMultiplier = 2f; // how much faster player goes
    private PlayerMovementBarebones playerMovement; // Change Player Speed
    private GameObject player;

    [Header("Jail Power Up")]
    //Jail Power Up
    [SerializeField] private float stunDuration = 3f; // how long dummy is frozen
    private PlayerMovementBarebones dummyMovement; // the dummy we stun / also needed for speed

    //Train Power Up
    [Header("Train Power Up")]
    // Whatever needed here


    private bool isCollected = false;
    private bool isUsing = false;
    private bool PWR_Boost = false;
    private bool PWR_Jail = false;
    private bool PWR_Train = false;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovementBarebones>();
    }

    // little bit weird tries double triggering Could add an enumerator in the real game
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PowerUp" && !isCollected)
        {
            isCollected = true;
            Debug.Log("Triggered with: Chance Card / Power Up");
            PowerPickUp();
            Destroy(collider.gameObject);
        }
        else if (collider.tag == "PowerUp")
        {
            Debug.Log("Triggered with: Chance Card / Power Up");
            Destroy(collider.gameObject);
        }
    }

    private void PowerPickUp()
    {
        if (!PWR_Boost || !PWR_Jail || !PWR_Train)
        {
            int randomIndex = Random.Range(0, 3);

            switch (randomIndex)
            {
                case 0:
                    PWR_Boost = true;
                    Debug.Log("PowerUp random = Boost");
                    powerUpUI.SetPowerUpImage("Boost");
                    break;
                case 1:
                    PWR_Jail = true;
                    Debug.Log("PowerUp random = Jail");
                    powerUpUI.SetPowerUpImage("Jail");
                    break;
                case 2:
                    PWR_Train = true;
                    Debug.Log("PowerUp random = Train");
                    powerUpUI.SetPowerUpImage("Train");
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(useKey) && isCollected)
        {
            isCollected = false;
            powerUpUI.ClearPowerUpIcon();

            // wait for player to press E to use the boost
            if (PWR_Boost && !isUsing)
            {
                PWR_Boost = false;
                Debug.Log("pressed (E) to use powerup Boost");
                StartCoroutine(UseBoost());
            }

            // wait for player to press E to use the Jail
            else if (PWR_Jail && !isUsing)
            {
                PWR_Jail = false;
                Debug.Log("pressed (E) to use powerup Jail");
                StartCoroutine(UseJail());
            }

            // wait for player to press E to use the Train
            else if (PWR_Train && !isUsing)
            {
                PWR_Train = false;
                Debug.Log("pressed (E) to use powerup Train");
                StartCoroutine(UseTrain());
            }
        }
    }

    private System.Collections.IEnumerator UseBoost()
    {
        isUsing = true;
        float originalPlayerSpeed = playerMovement.moveSpeed;
        playerMovement.moveSpeed *= speedMultiplier;
        yield return new WaitForSeconds(boostDuration);
        playerMovement.moveSpeed = originalPlayerSpeed;
        isUsing = false;
        isCollected = false;
        Debug.Log("Boost powerup ended");
    }

    private System.Collections.IEnumerator UseJail()
    {
        isUsing = true;

        // find the dummy in the scene to stun
        GameObject dummy = GameObject.FindWithTag("Dummy");
        if (dummy != null)
        {
            dummyMovement = dummy.GetComponent<PlayerMovementBarebones>();
        }
        else
        {
            Debug.LogWarning("no dummy target found for jail powerup");
        }

        // store dummy's speed so we can reset it
        float originalDummySpeed = dummyMovement.moveSpeed;
        dummyMovement.moveSpeed = 0f; // stun the dummy

        yield return new WaitForSeconds(stunDuration);

        dummyMovement.moveSpeed = originalDummySpeed; // back to normal
        isUsing = false;
        isCollected = false;
        Debug.Log("Jail powerup ended");
    }

    private System.Collections.IEnumerator UseTrain()
    {
        isUsing = true;

        // ** Code Needed **
        // insert // copy Here
        //  Villius section

        // Needs some code for now
        float originalPlayerSpeed = playerMovement.moveSpeed;
        playerMovement.moveSpeed *= speedMultiplier;
        yield return new WaitForSeconds(boostDuration);
        playerMovement.moveSpeed = originalPlayerSpeed;
        // Delete this later ^


        isUsing = false;
        isCollected = false;
        Debug.Log("Train powerup ended");
    }
}
