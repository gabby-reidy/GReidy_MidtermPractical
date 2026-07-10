using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float spawnInterval = 5f;
    private float obstacleCount = 0;
    private float maxObstacleCount = 6;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleCount <= maxObstacleCount)
        {
            SpawnObstacles();
        }
    }

    void SpawnObstacles() 
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform randomSpawnPoint = spawnPoints[spawnIndex];

        Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], randomSpawnPoint.position, Quaternion.identity);

        obstacleCount++;
    }
}
