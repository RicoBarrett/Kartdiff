using UnityEngine;

public class PWR_Jail : MonoBehaviour
{
    public float respawnTime = 5f; // how long till powerup comes back
    public float stunDuration = 3f; // how long dummy is frozen
    public KeyCode useKey = KeyCode.E; // key to activate

    private bool isCollected = false; // if someone picked it up
    private bool isUsing = false; // if it's currently being used
    private PlayerMovementBarebones targetMovement; // the dummy we stun

    void OnTriggerEnter(Collider other)
    {
        // only trigger if a player touches it
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            Debug.Log("jail powerup picked up");

            // hide powerup while it respawns
            gameObject.SetActive(false);
            Invoke(nameof(RespawnPowerUp), respawnTime);

            // find the dummy in the scene to stun
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

    void Update()
    {
        // press E to use it
        if (isCollected && !isUsing && Input.GetKeyDown(useKey))
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

    private System.Collections.IEnumerator UseJail()
    {
        isUsing = true;

        // store dummy's speed so we can reset it
        float originalSpeed = targetMovement.moveSpeed;
        targetMovement.moveSpeed = 0f; // stun the dummy

        yield return new WaitForSeconds(stunDuration);

        targetMovement.moveSpeed = originalSpeed; // back to normal
        isUsing = false;
        isCollected = false;
        Debug.Log("jail powerup ended");
    }

    void RespawnPowerUp()
    {
        // bring the powerup back
        gameObject.SetActive(true);
    }
}


//script was made using unity built in trigger and coroutine systems
//https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter.html
//https://docs.unity3d.com/Manual/Coroutines.html
//https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html
//https://www.youtube.com/watch?v=CLSiRf_OrBk&t=313s