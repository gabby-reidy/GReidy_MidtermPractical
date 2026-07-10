using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth = 15;
    private int currentHealth;
    private bool isDead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
}
