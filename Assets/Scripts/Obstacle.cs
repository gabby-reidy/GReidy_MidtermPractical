using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int damage;
    private float speed;
    private Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 7);
        damage = Random.Range(1, 6);
        speed = Random.Range(5, 15);
        direction = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f)).normalized;
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
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
