using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Assign the obstacle prefab in the Inspector
    public float spawnInterval = 4.0f; // Time between obstacle spawns
    public float minY = -3.0f; // Minimum Y position for spawning
    public float maxY = 3.0f;  // Maximum Y position for spawning
    public float minSpeed = 1.0f; // Minimum obstacle speed
    public float maxSpeed = 3.0f; // Maximum obstacle speed
    public float minSize = 0.3f;  // Minimum obstacle size
    public float maxSize = 1.0f;  // Maximum obstacle size

    private void Start()
    {
        // Start spawning obstacles repeatedly
        InvokeRepeating("SpawnObstacle", spawnInterval, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Generate a random Y position within the given range
        float spawnYPosition = Random.Range(minY, maxY);

        // Set spawn position at the right side of the screen
        Vector3 spawnPosition = new Vector3(Camera.main.aspect * Camera.main.orthographicSize + 2, spawnYPosition, 0);

        // Instantiate a new obstacle at the spawn position
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Randomize the size of the obstacle
        float randomSize = Random.Range(minSize, maxSize);
        newObstacle.transform.localScale = new Vector3(randomSize, randomSize, 1);

        // Randomize the speed and assign it to the obstacle's movement script
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        newObstacle.GetComponent<ObstacleMover>().speed = randomSpeed;
    }
}
