using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 0f;
    public Transform playerBody;
    private float xRotation = 0f;

    private bool cameraActive = true; // Add a boolean flag to control camera activity.

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!cameraActive)
        {
            return; // If the camera is not active, do not process mouse input.
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // Add a method to toggle camera activity externally.
    public void ToggleCameraActivity(bool active)
    {
        cameraActive = active;
    }
}