using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody[] coinPrefabs;
    [SerializeField] private float coinInterval = 3f;
    [SerializeField] private float initialDelay = .2f;
    [SerializeField] private float spawnDelay = 3f;
    private float maxPosition = 15f;
    private float minPosition = -15f;
    private float fixedYPosition = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Invoke(nameof(SpawnCoins), initialDelay);
        }

        InvokeRepeating(nameof(SpawnCoins), spawnDelay, coinInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// spawns coins at random location within bounds
    /// </summary>
    void SpawnCoins()
    {
        float xPosition = Random.Range(minPosition, maxPosition);
        float zPosition = Random.Range(-minPosition, maxPosition);

        Vector3 spawnPos = new Vector3(xPosition, fixedYPosition, zPosition);
        Instantiate(coinPrefabs[Random.Range(0, coinPrefabs.Length)], spawnPos, Quaternion.identity);
    }
}
