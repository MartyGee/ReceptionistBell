using UnityEngine;
using System.Collections.Generic;

public class PaperEvent : MonoBehaviour
{
    public List<GameObject> objectsToActivate = new List<GameObject>();
    public List<GameObject> objectsToDeactivate = new List<GameObject>();
    public List<GameObject> objectsToDestroy = new List<GameObject>(); // List for objects to destroy.
    public GameObject instruction;
    public GameObject thisTrigger;
    public GameObject paperUiElement; // The new UI element to open or activate.
    public AudioSource sound;
    public MouseLook mouseLookScript; // Reference to the MouseLook script.
    public CharacterController characterController; // Reference to the CharacterController.

    private float interactionDistance = 3f; // Maximum interaction distance.
    private bool isOpen = false; // Track if the object is open.
    private bool objectsActivated = false; // Track if objects have been activated.

    private void Start()
    {
        instruction.SetActive(false);
        paperUiElement.SetActive(false); // Initially, keep the UI element deactivated.
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
            instruction.SetActive(canInteract);

            // Check for player input to interact with the object
            if (Input.GetKeyDown(KeyCode.E) && canInteract)
            {
                if (!objectsActivated) // Check if objects are not already activated
                {
                    PerformAction(); // Perform the action when "E" is pressed.
                }
                else
                {
                    // If the UI is closed, reopen it
                    isOpen = true;
                    paperUiElement.SetActive(true);
                    UnlockCursor();
                    sound.Play();
                    mouseLookScript.ToggleCameraActivity(false);
                    characterController.enabled = false;
                }
            }
        }
        else
        {
            // Second phase: The player can close the object by pressing "E" regardless of where they are looking.
            if (Input.GetKeyDown(KeyCode.E))
            {
                EndAction(); // End the action when "E" is pressed.
            }
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

    // Perform the action when "E" is pressed
    private void PerformAction()
    {
        isOpen = true;
        paperUiElement.SetActive(true); // Activate the new UI element.
        UnlockCursor();
        sound.Play();

        // Block camera control.
        mouseLookScript.ToggleCameraActivity(false);
        // Disable character movement.
        characterController.enabled = false;

        // Activate objects in the list
        foreach (var obj in objectsToActivate)
        {
            obj.SetActive(true);
        }

        // Deactivate objects in the list
        foreach (var obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }

        // Destroy objects in the list
        foreach (var obj in objectsToDestroy)
        {
            Destroy(obj);
        }

        objectsActivated = true; // Set objectsActivated to true.
    }

    // End the action when "E" is pressed again
    private void EndAction()
    {
        isOpen = false;
        paperUiElement.SetActive(false); // Deactivate the new UI element.
        LockCursor();

        // Unblock camera control.
        mouseLookScript.ToggleCameraActivity(true);
        // Enable character movement.
        characterController.enabled = true;
    }

    // Lock the cursor
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Make the cursor invisible.
    }

    // Unlock the cursor
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Make the cursor visible.
    }
}