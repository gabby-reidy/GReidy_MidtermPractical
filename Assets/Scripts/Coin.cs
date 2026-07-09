using UnityEngine;

public class Coin : MonoBehaviour
{

    private float rotationSpeed = 10f;
    [SerializeField] private float moveSpeed = 10f;
    private bool isOnGround;
    private float yBound;
    private Rigidbody coinRb;
    [SerializeField] private float bounce = .5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinRb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(6, 7);
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
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            coinRb.AddForce(Vector3.up * bounce, ForceMode.Impulse);
        }
    }
}
