using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore;
    private int maxScore = 50;
    public bool HasWon;
    private CoinSpawner coinSpawner;
    private ObstacleSpawner obstacleSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinSpawner = GameObject.Find("CoinSpawner").GetComponent<CoinSpawner>();
        obstacleSpawner = GameObject.Find("ObstacleSpawners").GetComponent<ObstacleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// takes an int for score/points and adds it to current score
    /// also checks if the player has won the game, and destroys spawners if so
    /// </summary>
    /// <param name="score"></param>
    public void HandleScoring(int score)
    {
        currentScore += score;
        Debug.Log("Your current score is: " + currentScore);

        if (currentScore > maxScore)
        {
            HasWon = true;
            Destroy(coinSpawner);
            Destroy(obstacleSpawner);
            Debug.Log("You win");
        }
    }
}
