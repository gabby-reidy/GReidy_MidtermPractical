using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    private Vector3 cameraOffset = new Vector3(0, 1, 0);

    public float Distance = 5f;
    public float SensitivityX = 4f;
    public float SensitivityY = 4f;
    public float MinPitch = -20f;
    public float MaxPitch = 60f;

    private float yaw;
    private float pitch = 15f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Player == null)
        {
            return;
        }

        yaw += Input.GetAxis("Mouse X") * SensitivityX;
        pitch -= Input.GetAxis("Mouse Y") * SensitivityY;
        pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 focusPoint = Player.position + cameraOffset;
        Vector3 desiredPosition = focusPoint - rotation * Vector3.forward * Distance;

        transform.position = desiredPosition;
        transform.rotation = rotation;
    }
}
