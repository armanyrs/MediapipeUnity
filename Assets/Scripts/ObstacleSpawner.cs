using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 0.5f;
    public float minY = -5f; // ?? batas bawah layar
    public float maxY = 5f; // ?? batas atas layar

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        float randomY = Random.Range(minY, maxY);
        float spawnX = 8f; // spawn jauh di kanan layar
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0);
        Instantiate(obstaclePrefab, spawnPos,
        Quaternion.identity);
    }

    // Added so external callers (e.g. GameManager) can stop spawning
    public void StopSpawning()
    {
        CancelInvoke(nameof(SpawnObstacle));
    }
}