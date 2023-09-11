using UnityEngine;
using System.Collections.Generic;

public class CorkBoardAnimationScript : MonoBehaviour
{
    public List<GameObject> objectsToActivate; // List of objects to activate.
    public List<GameObject> objectsToDeactivate; // List of objects to deactivate after animation2.
    public Animator animator1; // Reference to the first Animator component
    public Animator animator2; // Reference to the second Animator component
    private bool objectsActivated = false; // Flag to track if objects are activated

    private void Start()
    {
        // You can add any additional setup logic here.
    }

    // Perform the action when the animation event is triggered
    public void ActivateObjects()
    {
        if (!objectsActivated)
        {
            objectsActivated = true; // Set the flag to true, indicating objects are activated.

            // Activate all objects in the list.
            foreach (GameObject obj in objectsToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
        }
    }

    // This method is called from an Animation Event at the end of animator2
    public void DeactivateObjects()
    {
        // Deactivate all objects in the list when the Animation Event is triggered.
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}