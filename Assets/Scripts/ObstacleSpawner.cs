using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float spawnInterval;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacles", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles() 
    {
        Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], new Vector3(26, 1.5f, -29), Quaternion.identity);
    }
}
