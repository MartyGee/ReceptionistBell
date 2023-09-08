using UnityEngine;
using System.Collections.Generic;

public class InteractAnimatedObjectV2 : MonoBehaviour
{
    public GameObject instruction;
    public AudioClip sound;
    public Animator animator;

    private float interactionDistance = 3f;
    private bool isOpen = false; // Track if the drawer is open.
    private bool isLookingAtObject = false;

    // Lists to store objects for activation and deactivation.
    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeactivate;

    private void Start()
    {
        instruction.SetActive(false);
    }

    private void Update()
    {
        // Continuously check if the player is looking at the object.
        isLookingAtObject = CanInteractWithObject();

        // If the player is looking at the object, show instruction1.
        if (isLookingAtObject)
        {
            instruction.SetActive(true);

            // Check for player input to interact with the object
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Toggle the isOpen flag and set the Animator parameter accordingly.
                animator.SetTrigger("IsOpen");

                AudioSource.PlayClipAtPoint(sound, transform.position);

                // Activate objects from the list.
                ActivateObjects(objectsToActivate);

                // Deactivate objects from the list.
                DeactivateObjects(objectsToDeactivate);
            }
        }
        else
        {
            instruction.SetActive(false);
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

    // Function to activate objects.
    private void ActivateObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
        objects.Clear();
    }

    // Function to deactivate objects.
    private void DeactivateObjects(List<GameObject> objects)
    {
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
        objects.Clear();
    }
}
