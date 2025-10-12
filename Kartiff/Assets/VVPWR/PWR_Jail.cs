using UnityEngine;
using System.Collections;

public class PWR_Jail : MonoBehaviour
{
    [Header("powerup settings")]
    public float respawnTime = 5f; // how long till powerup comes back
    public float stunDuration = 3f; // how long dummy is frozen
    public KeyCode useKey = KeyCode.E; // key to activate

    // internal variables
    private bool isCollected = false; // if someone picked it up
    private bool canUse = false; // if we can use it right now
    private bool isUsing = false; // if it's currently being used
    private PlayerMovementBarebones targetMovement; // the dummy we stun

    private void OnTriggerEnter(Collider other)
    {
        // only trigger if player touches it
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            canUse = true; // allow using instantly
            Debug.Log("jail powerup picked up");

            // hide visuals but keep script alive
            HidePickupVisuals();

            // start timer for respawn
            Invoke(nameof(RespawnPowerUp), respawnTime);

            // find dummy to target (the one that gets stunned)
            GameObject dummy = GameObject.FindWithTag("Dummy");
            if (dummy != null)
            {
                targetMovement = dummy.GetComponent<PlayerMovementBarebones>();
            }
            else
            {
                Debug.LogWarning("no dummy target found for jail powerup");
            }
        }
    }

    private void Update()
    {
        // check if player can use the powerup
        if (canUse && !isUsing && Input.GetKeyDown(useKey))
        {
            if (targetMovement != null)
            {
                Debug.Log("pressed (E) to use jail powerup");
                StartCoroutine(UseJail());
            }
            else
            {
                Debug.LogWarning("cannot use jail, no target set");
            }
        }
    }

    private IEnumerator UseJail()
    {
        isUsing = true;
        canUse = false;

        // store dummy speed to restore later
        float originalSpeed = targetMovement.moveSpeed;

        // freeze the dummy
        targetMovement.moveSpeed = 0f;
        Debug.Log("dummy stunned for " + stunDuration + " seconds");

        // wait for duration
        yield return new WaitForSeconds(stunDuration);

        // unfreeze dummy
        targetMovement.moveSpeed = originalSpeed;
        isUsing = false;
        isCollected = false;
        Debug.Log("jail powerup ended");
    }

    private void RespawnPowerUp()
    {
        // bring powerup visuals back
        ShowPickupVisuals();
        Debug.Log("jail powerup respawned");
    }

    private void HidePickupVisuals()
    {
        // turns off all meshes and sprites so it's invisible
        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var r in renderers) r.enabled = false;

        var sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var s in sprites) s.enabled = false;

        // disable collider so player can't grab it again yet
        var col = GetComponent<Collider>();
        if (col != null) col.enabled = false;
    }

    private void ShowPickupVisuals()
    {
        // turns on all meshes and sprites again
        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var r in renderers) r.enabled = true;

        var sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var s in sprites) s.enabled = true;

        // re-enable collider so it can be picked up again
        var col = GetComponent<Collider>();
        if (col != null) col.enabled = true;
    }
}

//script was made using unity built in trigger and coroutine systems
//https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter.html
//https://docs.unity3d.com/Manual/Coroutines.html
//https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html
//https://www.youtube.com/watch?v=CLSiRf_OrBk&t=313s