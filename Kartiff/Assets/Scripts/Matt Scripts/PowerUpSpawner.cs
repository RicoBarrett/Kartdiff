using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject powerUpPrefab; // The prefab to spawn
    [SerializeField] private float respawnDelay = 5f;  // Seconds before respawn

    private GameObject currentPowerUp;

    private void Start()
    {
        SpawnPowerUp();
        StartCoroutine(WatchForRespawn());
    }

    private void SpawnPowerUp()
    {
        // Spawn the PowerUp prefab as a child of this prefab spawner
        currentPowerUp = Instantiate(powerUpPrefab, transform);
    }

    private IEnumerator WatchForRespawn()
    {
        while (true)
        {
            if (currentPowerUp == null)
            {
                // Wait a delay before respawning
                yield return new WaitForSeconds(respawnDelay);
                SpawnPowerUp();
            }

            // Wait one frame before checking again
            yield return null;
        }
    }
}
