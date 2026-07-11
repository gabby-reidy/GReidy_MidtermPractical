using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 50;
    private int currentHealth;
    public bool IsDead;
    private CoinSpawner coinSpawner;
    private ObstacleSpawner obstacleSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinSpawner = GameObject.Find("CoinSpawner").GetComponent<CoinSpawner>();
        obstacleSpawner = GameObject.Find("ObstacleSpawners").GetComponent<ObstacleSpawner>();
        SetStartingHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sets players starting health to max and prints to console.
    /// </summary>
    void SetStartingHealth()
    {
        currentHealth = maxHealth;
        Debug.Log("Your current health is " + currentHealth);
    }

    /// <summary>
    /// takes an int parameter for damage and subtracts it from players current health
    /// also checks for death, and destorys spawners if so
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("You took " + damage + "Your health is now " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            IsDead = true;
            Destroy(coinSpawner);
            Destroy(obstacleSpawner);
            Debug.Log("You lose");
        }
    }

}
