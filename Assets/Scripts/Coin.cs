using UnityEngine;

public class Coin : MonoBehaviour
{

    private float rotationSpeed = 10f;
    [SerializeField] private float moveSpeed = 10f;
    private bool isOnGround;
    private Rigidbody coinRb;
    [SerializeField] private float bounce = .5f;
    [SerializeField] private int value;
    private ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinRb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(6, 7);
        scoreManager = GameObject.Find("Player").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        MoveUpAndDown();
    }
    /// <summary>
    /// Makes the coin rotate on y axis continuously
    /// </summary>
    void Rotate()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Checks if the coin is on the ground, and moves it up and down accordingly
    /// </summary>
    void MoveUpAndDown()
    {
        if (isOnGround == true)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

    }
    /// <summary>
    /// Checks for collisions with the player and ground objects
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scoreManager.HandleScoring(value);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            coinRb.AddForce(Vector3.up * bounce, ForceMode.Impulse);
        }
    }
}
