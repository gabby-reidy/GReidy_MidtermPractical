using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private bool isOnGround;

    private Vector3 movement;
    private int moveSpeed = 10;
    private int jumpForce = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    void HandleMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    /// <summary>
    /// Allows player to jump if they are on the ground, and prevents double jumping
    /// </summary>
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
}
