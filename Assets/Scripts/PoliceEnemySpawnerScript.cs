using UnityEngine;

public class PoliceEnemySpawnerScript : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnInterval = 7f; // Adjust this to control the time between spawns
    private float spawnTimer = 0f;
    private Transform player; // Reference to the player's transform

    private void Update()
    {
        // Countdown the timer
        spawnTimer -= Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (spawnTimer <= 0f)
        {
            float random = Random.Range(0f, 1f);
            Debug.Log(random);
            if (random > .8)
                SpawnEnemy(3);  
            spawnTimer = spawnInterval; // Reset the timer
        }

    }

    private void SpawnEnemy(int numberOfEnemies)
    {
        // Find the player's GameObject by its tag (You should assign the "Player" tag to your player GameObject)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        // Instantiate the enemy prefab at the spawner's position
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject newEnemy = EnemyObjectPool2.SharedInstance.GetPooledObject(); 
            if (newEnemy != null) {
            newEnemy.transform.position = transform.position;
            newEnemy.SetActive(true);

             EnemyMovement movementScript = newEnemy.GetComponent<EnemyMovement>();
            if (movementScript != null)
            {
                movementScript.SetDestination(playerObject.transform.position);
            }
        }
        }
        
       
    }
}