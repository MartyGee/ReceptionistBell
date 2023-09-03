using UnityEngine;

public class InteractableStaticObject : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject ThisTrigger;
    public AudioClip Sound;
    public float interactionDistance = 5f; // Maximum interaction distance.

    private bool actionInProgress = false;

    private void Start()
    {
        Instruction.SetActive(false);
    }

    private void Update()
    {
        // Check if the player is looking at the object and within the interaction distance
        bool canInteract = CanInteractWithObject();

        // Show or hide the instruction based on whether the player can interact
        Instruction.SetActive(canInteract);

        // Check for player input to interact with the object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canInteract)
            {
                if (!actionInProgress)
                {
                    PerformAction(); // Perform the action when "E" is pressed.
                }
                else
                {
                    EndAction(); // End the action when "E" is pressed again.
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
        // Perform the action you want to execute when "E" is pressed.
        // For example, you can play a sound or activate a UI element.
        // Here, we're just marking the action as in progress.
        actionInProgress = true;
    }

    // End the action when "E" is pressed again
    private void EndAction()
    {
        // End the action you previously started.
        // For example, you can stop playing a sound or deactivate a UI element.
        // Here, we're just marking the action as complete.
        actionInProgress = false;
    }
}