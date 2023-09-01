using UnityEngine;

public class TestClickableObject : MonoBehaviour
{
    public GameObject player;
    public Color normalColor = Color.white;
    public Color clickedColor = Color.red;
    public MouseLook cameraScript;

    [Header("Debug Variables")]
    public bool isMouseOver = false;
    public bool isPickedUp = false;
    public bool isMouseButtonDown = false;
    public bool isRotating = false;
    public bool isObjectHeld = false;
    public bool isInteracting = false;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = normalColor;
    }

    void Update()
    {
        // Use Physics.Raycast with infinite distance
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue))
        {
            if (hit.collider.gameObject == gameObject)
            {
                isMouseOver = true;
            }
            else
            {
                isMouseOver = false;
            }
        }
        else
        {
            isMouseOver = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            HandleEKeyPress();
        }

        if (isPickedUp && isInteracting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMouseButtonDown = true;
                isObjectHeld = true;
                LockCamera();
            }

            if (isMouseButtonDown && Input.GetMouseButton(0))
            {
                isRotating = true;
                RotateObject();
            }
            else if (isMouseButtonDown && Input.GetMouseButtonUp(0))
            {
                isMouseButtonDown = false;
                isRotating = false;
                UnlockCamera();
            }
        }
        else
        {
            isMouseButtonDown = false;
            isObjectHeld = false;
            UnlockCamera();
        }
    }

    void RotateObject()
    {
        if (isPickedUp && isMouseOver)
        {
            float rotationSpeed = 5f;
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            // Rotate the picked up object based on mouse movement
            transform.Rotate(Vector3.up, -mouseX, Space.World);
            transform.Rotate(Vector3.right, mouseY, Space.World);
        }
    }

    void LockCamera()
    {
        cameraScript.enabled = false;
    }

    void UnlockCamera()
    {
        cameraScript.enabled = true;
    }

    void HandleEKeyPress()
    {
        // Check if the player is within the threshold distance and the object is in range
        if (isPickedUp && isInteracting)
        {
            isPickedUp = false;
            isObjectHeld = false;
            UnlockCamera();
            isInteracting = false; // Cease all interactions
        }
        else if (isMouseOver && player.GetComponent<PickUpScript>().IsInRange) // Only pick up if mouse is over and in range
        {
            isPickedUp = true;
            isInteracting = true; // Start interactions
        }
    }
}




//Questo script è solo un test per separare la funzione "oggetto interagibile" dallo script originale (BellSoundClickableObject).