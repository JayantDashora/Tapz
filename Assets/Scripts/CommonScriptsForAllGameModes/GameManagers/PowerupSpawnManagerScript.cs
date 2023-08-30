using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnManagerScript : MonoBehaviour
{
    // Variables

    [SerializeField] private List<GameObject> powerups = new List<GameObject>();

    // Functions

    IEnumerator Start() {
        yield return new WaitForSeconds(Random.Range(60,120));
        StartCoroutine(SpawnPowerup()); // Start the coroutine
    }

    // Generate a spawn point for the powerup

    IEnumerator SpawnPowerup(){

        while (true) // Infinite loop to keep spawning
        {
            Vector3 spawnPoint = Vector3.zero;

            spawnPoint.x = Random.Range(0.1f, 0.9f);
            spawnPoint.y = Random.Range(0.1f, 0.9f);

            Vector3 worldSpawnPoint = Camera.main.ViewportToWorldPoint(spawnPoint);
            worldSpawnPoint.z = 0;

            if (Physics2D.OverlapCircleAll(worldSpawnPoint, 0.3f).Length == 0)
            {
                // Add game juice here
                Instantiate(powerups[Random.Range(0, powerups.Count)], worldSpawnPoint, Quaternion.identity);
            }

            yield return new WaitForSeconds(Random.Range(60,120));
        }
    }
}
