using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int rotationSpeed = 10;
    [SerializeField] private float jumpVelocity = 10f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private int fallMultiplier = 5;
    private bool hasJumped;
    private float verticalVelocity;

    [SerializeField] private Transform cameraTransform;
    private CharacterController controller;
    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
        if (cameraTransform != null)
        {
            cam = cameraTransform.GetComponent<Camera>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 cameraMovement = (cameraRight * moveX + cameraForward * moveZ).normalized;

        bool isFalling = verticalVelocity < 0f && hasJumped;
        float gravityThisFrame = gravity;
        if(isFalling)
        {
            gravityThisFrame *= fallMultiplier;
        }
        verticalVelocity += gravity * Time.deltaTime;

        if(controller.isGrounded)
        {
            if(verticalVelocity < 0f)
            {
                verticalVelocity = -2f;
                hasJumped = false;
            }
            if(Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpVelocity;
                hasJumped = true;
            }
        }

        if(cameraMovement.sqrMagnitude > .001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraMovement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        Vector3 movement = cameraMovement * speed;
        controller.Move((movement + Vector3.up * verticalVelocity) * Time.deltaTime);
    }
}
