using UnityEngine;
using System.Collections.Generic;

public class CabinetLockedText : MonoBehaviour
{
    public List<GameObject> objectsToDeactivate; // List of objects to deactivate when "E" is pressed.

    public GameObject instruction1;
    public GameObject instruction2; // The new UI element to open or activate.
    public AudioClip sound;
    public Animator animator1; // Reference to the first Animator component
    public Animator animator2; // Reference to the second Animator component

    private float interactionDistance = 3f; // Maximum interaction distance.
    private bool isOpen = false; // Track if the object is open;
    private bool isLookingAtObject = false; // Track if the player is looking at the object.

    private void Start()
    {
        instruction1.SetActive(false);
        instruction2.SetActive(false); // Initially, keep the UI element deactivated.
        LockCursor();
    }

    private void Update()
    {
        if (!isOpen)
        {
            // First phase: The player needs to be looking at the object to open it.
            // Check if the player is looking at the object and within the interaction distance
            bool canInteract = CanInteractWithObject();

            // Show or hide the instruction based on whether the player can interact
            instruction1.SetActive(canInteract);

            // Check for player input to interact with the object
            if (Input.GetKeyDown(KeyCode.E) && canInteract)
            {
                PerformAction(); // Perform the action when "E" is pressed.
            }
        }
    }

    private void FixedUpdate()
    {
        // Continuously check if the player is looking at the object.
        isLookingAtObject = CanInteractWithObject();

        // If the object is open and the player is not looking at it, hide instruction2.
        if (isOpen && !isLookingAtObject)
        {
            instruction2.SetActive(false);
        }
    }

    // Checks if the player is looking at the object and within the interaction distance
    private bool CanInteractWithObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform a raycast to check if the player's line of sight intersects with the object.
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Check if the object hit by the raycast is this object.
            if (hit.collider.gameObject == gameObject)
            {
                return true; // Player is looking at and within the interaction distance.
            }
        }

        return false; // Player is not looking at the object or is too far away.
    }

    private void PerformAction()
    {
        isOpen = true;
        instruction1.SetActive(false); // Deactivate instruction1.
        instruction2.SetActive(true); // Activate instruction2.
        LockCursor(); // Lock the cursor when the action starts.
        AudioSource.PlayClipAtPoint(sound, transform.position);

        // Trigger animations if Animator components are available
        if (animator1 != null)
        {
            animator1.SetTrigger("IsActive");
        }
        if (animator2 != null)
        {
            animator2.SetTrigger("IsActive1");
        }

        // Deactivate a list of objects (add more if needed)
        DeactivateObjects();
    }

    // Add this method to deactivate a list of objects
    private void DeactivateObjects()
    {
        foreach (var obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }

    // End the action when "E" is pressed again
    private void EndAction()
    {
        isOpen = false;
        instruction2.SetActive(false); // Deactivate instruction2.
        LockCursor(); // Lock the cursor when the action ends.
    }

    // Lock the cursor
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Make the cursor invisible.
    }
}

