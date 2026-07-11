using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private float spawnInterval = 2f;
    public int ObstacleCount;

    // private float maxObstacleCount = 5; <-- leaving this commented out, I tried several ways to try to implement
    // a max obstacle count, and all of them broke my code so I gave up, but would love feedback on how to implement in the future


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacles), spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void SpawnObstacles() 
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform randomSpawnPoint = spawnPoints[spawnIndex];  

        GameObject spawn = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], randomSpawnPoint.position, Quaternion.identity);
        Obstacle obstacleRef = spawn.GetComponent<Obstacle>();

        ObstacleCount++;
    }
}
