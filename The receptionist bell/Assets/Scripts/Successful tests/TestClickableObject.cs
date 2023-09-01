using UnityEngine;

public class TestClickableObject : MonoBehaviour
{
    public GameObject player;
    public float thresholdDistance = 5f;
    public Color normalColor = Color.white;
    public Color clickedColor = Color.red;
    public MouseLook cameraScript;

    [Header("Debug Variables")]
    public bool isMouseOver = false;
    public bool isPickedUp = false;
    public bool isMouseButtonDown = false;
    public bool isRotating = false;
    public bool isObjectHeld = false;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = normalColor;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < thresholdDistance)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
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
        }
        else
        {
            isMouseOver = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            HandleEKeyPress();
        }

        if (isPickedUp)
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
        if (isPickedUp)
        {
            isPickedUp = false;
            isObjectHeld = false;
            UnlockCamera();
        }
        else if (isMouseOver) // Only pick up the object if the mouse is over it
        {
            isPickedUp = true;
        }
    }
}




//Questo script è solo un test per separare la funzione "oggetto interagibile" dallo script originale (BellSoundClickableObject).