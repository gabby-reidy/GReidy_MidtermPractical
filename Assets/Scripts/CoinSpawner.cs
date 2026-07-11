using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody[] coinPrefabs;
    public float CoinInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Invoke(nameof(SpawnCoins), .2f);
        }

        InvokeRepeating(nameof(SpawnCoins), 3f, 3f);
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
        float xPosition = Random.Range(-15f, 15f);
        float yPosition = 1;
        float zPosition = Random.Range(-15f, 15f);

        Vector3 spawnPos = new Vector3(xPosition, yPosition, zPosition);
        Instantiate(coinPrefabs[Random.Range(0, coinPrefabs.Length)], spawnPos, Quaternion.identity);
    }
}
