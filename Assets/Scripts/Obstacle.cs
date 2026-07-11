using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int damage;
    private float speed;
    private Vector3 direction;
    private Rigidbody obstacleRb;
    private ObstacleSpawner obstacleSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
        obstacleRb = GetComponent<Rigidbody>();
        damage = Random.Range(1, 6);
        speed = Random.Range(5, 15);
        direction = new Vector3(Random.Range(-5f, 5f), 1f, Random.Range(-5f, 5f)).normalized;
        obstacleRb.linearVelocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyAndRespawn();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            DestroyAndRespawn();
        }
    }

    private void DestroyAndRespawn()
    {
        Destroy(gameObject);
        if (obstacleSpawner != null)
        {
            obstacleSpawner.SpawnObstacles();
        }
    }
}
