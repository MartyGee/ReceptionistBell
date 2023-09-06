using UnityEngine;
using UnityEngine.Events;

public class RightDrawer : MonoBehaviour
{
    public GameObject instruction1;
    public AudioClip sound;
    public Animator animator;

    private float interactionDistance = 3f;
    private bool isOpen = false; // Track if the drawer is open.
    private bool isLookingAtObject = false;

    // Create a Unity event to be triggered when the animation finishes.
    public UnityEvent onAnimationFinished;

    private void Start()
    {
        instruction1.SetActive(false);
        LockCursor();

        // Subscribe to the Unity event with a function to activate instruction1.
        onAnimationFinished.AddListener(ActivateInstruction1);
    }

    private void Update()
    {
        // Continuously check if the player is looking at the object.
        isLookingAtObject = CanInteractWithObject();

        // If the player is looking at the object, show instruction1.
        if (isLookingAtObject)
        {
            instruction1.SetActive(true);

            // Check for player input to interact with the object
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Toggle the isOpen flag and set the Animator parameter accordingly.
                isOpen = !isOpen;
                animator.SetBool("IsOpen", isOpen);

                LockCursor();
                AudioSource.PlayClipAtPoint(sound, transform.position);
            }
        }
        else
        {
            instruction1.SetActive(false);
        }
    }

    private bool CanInteractWithObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }

        return false;
    }

    // Function to activate instruction1 when the animation finishes.
    private void ActivateInstruction1()
    {
        instruction1.SetActive(true);
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}




