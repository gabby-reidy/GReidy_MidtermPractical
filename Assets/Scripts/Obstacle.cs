using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int damage;
    private float speed;
    private Vector3 direction;
    private Rigidbody obstacleRb;
    private ObstacleSpawner obstacleSpawner;
    private PlayerHealth playerHealth;
    private float minPosition = -5f;
    private float maxPosition = 5f;
    private float fixedYPosition = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
        obstacleRb = GetComponent<Rigidbody>();
        damage = Random.Range(1, 6);
        speed = Random.Range(5, 15);
        direction = new Vector3(Random.Range(minPosition, maxPosition), fixedYPosition, Random.Range(minPosition, maxPosition)).normalized;
        obstacleRb.linearVelocity = direction * speed;
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
    /// <summary>
    /// checks for collisions between player and wall
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.Damage(damage);
            DestroyAndRespawn();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            DestroyAndRespawn();
        }
    }
    /// <summary>
    /// Destroys the object, and then calls the spawn obstacle method from obstaclespawner script to spawn a new obstacle in its place
    /// </summary>
    private void DestroyAndRespawn()
    {
        Destroy(gameObject);
        if (obstacleSpawner != null)
        {
            obstacleSpawner.SpawnObstacles();
        }
    }
}
