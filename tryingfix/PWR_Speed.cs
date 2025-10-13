using UnityEngine;

public class PWR_Speed : MonoBehaviour
{
    public float respawnTime = 5f; // time before powerup comes back
    public float boostDuration = 5f; // how long speed boost lasts
    public float speedMultiplier = 2f; // how much faster player goes
    public KeyCode useKey = KeyCode.E; // key to use boost

    private bool isCollected = false;
    private bool isUsing = false;
    private GameObject player;
    private PlayerMovementBarebones playerMovement;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            player = other.gameObject;
            playerMovement = player.GetComponent<PlayerMovementBarebones>();

            if (playerMovement != null)
            {
                isCollected = true;
                Debug.Log("powerup picked up");

                // hide it for respawn time
                gameObject.SetActive(false);
                Invoke(nameof(RespawnPowerUp), respawnTime);
            }
        }
    }

    void Update()
    {
        // wait for player to press E to use the boost
        if (isCollected && !isUsing && Input.GetKeyDown(useKey))
        {
            Debug.Log("pressed (E) to use powerup");
            StartCoroutine(UsePowerUp());
        }
    }

    private System.Collections.IEnumerator UsePowerUp()
    {
        isUsing = true;
        float originalSpeed = playerMovement.moveSpeed;
        playerMovement.moveSpeed *= speedMultiplier;
        yield return new WaitForSeconds(boostDuration);
        playerMovement.moveSpeed = originalSpeed;
        isUsing = false;
        isCollected = false;
        Debug.Log("powerup ended");
    }

    void RespawnPowerUp()
    {
        gameObject.SetActive(true);
    }
}


//main idea based on temporary player speed buffs from various unity tutorials
//https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter.html
//https://docs.unity3d.com/Manual/Coroutines.html
//https://docs.unity3d.com/ScriptReference/Rigidbody.html
//https://www.youtube.com/watch?v=CLSiRf_OrBk&t=313s