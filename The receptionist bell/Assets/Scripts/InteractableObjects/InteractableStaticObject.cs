using UnityEngine;

public class InteractableStaticObject : MonoBehaviour
{
    public GameObject instruction;
    public GameObject thisTrigger;
    public GameObject paperUiElement; // The new UI element to open or activate.
    public AudioSource sound;
    private float interactionDistance = 3f; // Maximum interaction distance.

    private bool actionInProgress = false;

    private void Start()
    {
        instruction.SetActive(false);
        paperUiElement.SetActive(false); // Initially, keep the UI element deactivated.
    }

    private void Update()
    {
        // Check if the player is looking at the object and within the interaction distance
        bool canInteract = CanInteractWithObject();

        // Show or hide the instruction based on whether the player can interact
        instruction.SetActive(canInteract);

        // Check for player input to interact with the object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canInteract)
            {
                if (!actionInProgress)
                {
                    PerformAction(); // Perform the action when "E" is pressed.
                    Time.timeScale = 0f;
                }
                else
                {
                    EndAction(); // End the action when "E" is pressed again.
                    Time.timeScale = 1f;
                }
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
        actionInProgress = true;
        paperUiElement.SetActive(true); // Activate the new UI element.
        Cursor.lockState = CursorLockMode.None;
        sound.Play();
    }

    // End the action when "E" is pressed again
    private void EndAction()
    {
        actionInProgress = false;
        paperUiElement.SetActive(false); // Deactivate the new UI element.
        Cursor.lockState = CursorLockMode.Locked;
    }
}