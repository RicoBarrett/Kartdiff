using System.Collections;
using UnityEngine;

public class PWR_Train : MonoBehaviour
{
    [Header("train settings")]
    public float trainDuration = 5f;
    public float speedMultiplier = 3f;
    public Transform[] waypoint;

    [Header("references")]
    public GameObject trainModel;
    public GameObject playerModel;
    public PlayerMovementBarebones playerMovement;
    public Rigidbody playerRb;

    [Header("respawn settings")]
    public float respawnDelay = 5f;

    private bool isCollected = false;
    private bool isTrainMode = false;
    private int currentWaypointIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Train powerup picked up");
            isCollected = true;
            StartCoroutine(HandlePickup(other.gameObject));
        }
    }

    private IEnumerator HandlePickup(GameObject player)
    {
        // hide visuals but keep component active so coroutine continues
        HidePickupVisuals();

        Debug.Log("Press E to activate Train Mode");

        bool activated = false;
        while (!activated)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                activated = true;
                Debug.Log("Train Mode activated");
                StartCoroutine(TrainModeRoutine());
            }
            yield return null;
        }

        // respawn after delay (show visuals again)
        yield return new WaitForSeconds(respawnDelay);
        ShowPickupVisuals();
        isCollected = false;
        Debug.Log("Train powerup respawned");
    }

    private IEnumerator TrainModeRoutine()
    {
        if (isTrainMode) yield break;
        isTrainMode = true;

        // swap visuals
        if (playerModel != null) playerModel.SetActive(false);
        if (trainModel != null) trainModel.SetActive(true);

        // boost speed
        float originalSpeed = playerMovement.moveSpeed;
        playerMovement.moveSpeed *= speedMultiplier;

        // disable manual movement (but keep this script running)
        playerMovement.enabled = false;

        // auto-drive setup
        currentWaypointIndex = 0;
        float elapsed = 0f;

        while (elapsed < trainDuration)
        {
            if (waypoint != null && waypoint.Length > 0 && currentWaypointIndex < waypoint.Length)
            {
                Vector3 target = waypoint[currentWaypointIndex].position;
                Vector3 direction = (target - playerRb.transform.position).normalized;
                playerRb.MovePosition(playerRb.transform.position + direction * playerMovement.moveSpeed * Time.deltaTime);

                if (Vector3.Distance(playerRb.transform.position, target) < 1f)
                {
                    currentWaypointIndex++;
                }
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        // revert
        if (trainModel != null) trainModel.SetActive(false);
        if (playerModel != null) playerModel.SetActive(true);
        playerMovement.moveSpeed = originalSpeed;
        playerMovement.enabled = true;
        isTrainMode = false;

        Debug.Log("Train Mode ended");
    }

    // hides everything related to the pickup (used when the player picks it up)
    private void HidePickupVisuals()
    {
        // get all 3d mesh renderers in this object and its children
        var renderers = GetComponentsInChildren<MeshRenderer>();
        // turn them off so the object becomes invisible
        foreach (var r in renderers) r.enabled = false;

        // same thing but for 2d sprites (in case the pickup uses a sprite instead of a mesh)
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var s in sprites) s.enabled = false;

        // also disable the collider so the player can’t trigger it again while it’s hidden
        var col = GetComponent<Collider>();
        if (col != null) col.enabled = false;
    }

    // shows everything again (used when the powerup respawns)
    private void ShowPickupVisuals()
    {
        // get all 3d meshes again and turn them back on
        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var r in renderers) r.enabled = true;

        // same thing for 2d sprites
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var s in sprites) s.enabled = true;

        // enable collider again so the pickup becomes interactable
        var col = GetComponent<Collider>();
        if (col != null) col.enabled = true;
    }

}

//Code is inspired by videos listed below; Code snippets from videos, Altered to suit the game
//Brackeys – “POWER UPS in Unity” (YouTube)
//https://www.youtube.com/watch?v=CLSiRf_OrBk
//Unity — status effect system tutorial
//https://www.youtube.com/watch?v=_N6Zv4TOCtM
//Unity Learn – Coroutines & Timers
//https://learn.unity.com/tutorial/coroutines