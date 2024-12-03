using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Item Spawner Settings")]
    public GameObject[] itemPrefabs;      // Array to hold different item prefabs
    public float spawnInterval = 1.5f;    // Interval between spawns
    public int itemsPerWave = 3;          // Number of items to spawn at each interval
    public float itemLifetime = 5.0f;     // Default lifetime for each item before it disappears

    private float spawnTimer;

    private void Update()
    {
        // Countdown timer for spawning new items
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnItems();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnItems()
    {
        // Get screen width to ensure items spawn within screen boundaries
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize;

        for (int i = 0; i < itemsPerWave; i++)
        {
            // Select a random item prefab from the array
            GameObject randomItem = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

            // Set a random x position within the screen width
            Vector2 spawnPosition = new Vector2(Random.Range(-screenWidth, screenWidth), Camera.main.orthographicSize);

            // Instantiate the random item at the calculated position
            GameObject item = Instantiate(randomItem, spawnPosition, Quaternion.identity);

            // Destroy the item after the specified lifetime if it's not collected
            Destroy(item, itemLifetime);
        }
    }
}
