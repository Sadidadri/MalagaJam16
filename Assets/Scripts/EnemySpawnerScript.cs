using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f; // Adjust this to control the time between spawns
    public Transform destination; // Assign the destination position in the Inspector
    private float spawnTimer = 0f;

    private void Update()
    {
        // Countdown the timer
        spawnTimer -= Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval; // Reset the timer
        }
    }

    private void SpawnEnemy()
    {
        // Instantiate the enemy prefab at the spawner's position
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        EnemyMovement movementScript = newEnemy.GetComponent<EnemyMovement>();
        if (movementScript != null)
        {
            movementScript.SetDestination(destination.position);
        }
    }
}