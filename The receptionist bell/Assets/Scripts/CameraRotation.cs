using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float xRotationLimit = 90f;
    public float yRotationLimit = 90f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xRotationLimit, xRotationLimit);

        yRotation += mouseX;
        

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}