using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentScore;
    private int maxScore = 50;
    public bool HasWon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleScoring(int score)
    {
        currentScore += score;
        Debug.Log("Your current score is: " + currentScore);

        if (currentScore > maxScore)
        {
            HasWon = true;
            Debug.Log("You win");
        }
    }
}
