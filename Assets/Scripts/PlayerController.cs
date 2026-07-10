using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private bool isOnGround;

    private Vector3 movement;
    private Transform cameraTransform;

    [SerializeField] private float moveSpeed = 20;
    [SerializeField] private float jumpForce = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
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
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 cameraTransformForward = cameraTransform.forward;
        Vector3 cameraTransformRight = cameraTransform.right;
        cameraTransformForward.y = 0;
        cameraTransformRight.y = 0;
        cameraTransformForward.Normalize();
        cameraTransformRight.Normalize();

        Vector3 cameraDirection = (cameraTransformForward * horizontalInput + cameraTransformRight * verticalInput).normalized;

        movement = cameraDirection * moveSpeed;
        playerRb.AddForce(movement, ForceMode.Force);
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
