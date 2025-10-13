using UnityEngine;

public class PWR_Speed : MonoBehaviour
{
    public float respawnTime = 5f; // how long till powerup comes back
    public float boostDuration = 4f; // how long player stays fast
    public float speedMultiplier = 1.8f; // how much faster player gets
    public KeyCode useKey = KeyCode.E; // key to activate

    private bool isCollected = false; // if someone picked it up
    private bool isUsing = false; // if it's currently being used
    private PlayerMovementBarebones playerMovement; // player movement script

    private MeshRenderer[] renderers; // visuals
    private Collider col; // collider

    void Start()
    {
        // get all renderers + collider on start
        renderers = GetComponentsInChildren<MeshRenderer>();
        col = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        // only trigger if a player touches it
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            Debug.Log("speed powerup picked up");

            // hide only visuals and collider, not the script
            HidePickupVisuals();

            // store player movement script
            playerMovement = other.GetComponent<PlayerMovementBarebones>();
            if (playerMovement == null)
            {
                Debug.LogWarning("no PlayerMovementBarebones script found on player");
            }
        }
    }

    void Update()
    {
        // press E to use the boost instantly after pickup
        if (isCollected && !isUsing && Input.GetKeyDown(useKey))
        {
            if (playerMovement != null)
            {
                Debug.Log("pressed (E) to use speed powerup");
                StartCoroutine(UseSpeedBoost());
            }
            else
            {
                Debug.LogWarning("cannot use speed boost, playerMovement not set");
            }
        }
    }

    private System.Collections.IEnumerator UseSpeedBoost()
    {
        isUsing = true;

        // store original speed
        float originalSpeed = playerMovement.moveSpeed;

        // apply boost
        playerMovement.moveSpeed *= speedMultiplier;
        Debug.Log("speed boost active");

        yield return new WaitForSeconds(boostDuration);

        // reset to normal
        playerMovement.moveSpeed = originalSpeed;
        Debug.Log("speed boost ended");

        // reset flags
        isUsing = false;
        isCollected = false;

        // respawn visuals after delay
        yield return new WaitForSeconds(respawnTime);
        ShowPickupVisuals();
        Debug.Log("speed powerup respawned");
    }

    void HidePickupVisuals()
    {
        // hides all visual parts
        foreach (var r in renderers)
            r.enabled = false;

        if (col != null)
            col.enabled = false;
    }

    void ShowPickupVisuals()
    {
        // brings visuals back
        foreach (var r in renderers)
            r.enabled = true;

        if (col != null)
            col.enabled = true;
    }
}


//script uses unity built in trigger and coroutine systems
//https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter.html
//https://docs.unity3d.com/Manual/Coroutines.html
//https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html

//inspired by
//https://www.youtube.com/watch?v=4HpC--2iowE

//boost logic reference
//https://www.youtube.com/watch?v=9NQ-mqY4a5k
