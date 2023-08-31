using UnityEngine;

public class TestClickableObject : MonoBehaviour
{
    public GameObject player;
    public float thresholdDistance = 5f;
    public Color normalColor = Color.white;
    public Color clickedColor = Color.red;
    public MouseLook cameraScript;
    private Renderer rend;
    private bool isMouseOver = false;
    private bool isPickedUp = false;

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

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        isPickedUp = !isPickedUp;

                        if (!isPickedUp)
                        {
                            // Unlock the camera when object is not picked up
                            cameraScript.enabled = true;
                        }
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
        }
        else
        {
            isMouseOver = false;
        }

        if (isPickedUp)
        {
            if (Input.GetMouseButton(0) && isMouseOver)
            {
                cameraScript.enabled = false; // Lock the camera when rotating the picked up object

                float rotationSpeed = 5f;
                float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

                // Rotate the picked up object based on mouse movement
                transform.Rotate(Vector3.up, -mouseX, Space.World);
            }
        }
    }
}

//Questo script è solo un test per separare la funzione "oggetto interagibile" dallo script originale (BellSoundClickableObject).