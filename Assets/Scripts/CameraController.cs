using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float yMinimum = -50f;
    private float yMaximum = 50f;

    public Transform Player;
    private Vector3 cameraOffset = new Vector3(0, 1, 0);

    public float Distance = 10f;
    private float currentX;
    private float currentY;
    private Vector3 lookAt;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentX, yMinimum, yMaximum);

        Quaternion playerRotation = Quaternion.Euler(currentX, currentY, 0f);
        transform.rotation = playerRotation;

        lookAt = Player.position + cameraOffset;
        transform.position = lookAt - playerRotation * Vector3.forward * Distance;

    }
}
