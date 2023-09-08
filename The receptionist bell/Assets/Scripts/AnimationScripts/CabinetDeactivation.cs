using UnityEngine;
using System.Collections.Generic;

public class CabinetDeactivation : MonoBehaviour
{
    public Transform objectToManipulate; // Reference to the object you want to manipulate
    public List<GameObject> objectsToActivate = new List<GameObject>(); // List of GameObjects to activate after animation finishes
    public Animator objectAnimator; // Reference to the Animator component
    public GameObject objectToDeactivate; // Reference to the animated object you want to deactivate

    public Vector3 desiredPosition = new Vector3(0f, 0f, 0f);
    public Vector3 desiredRotation = new Vector3(0f, 0f, 0f); // Initial rotation, you can change this
    public Vector3 desiredScale = new Vector3(0f, 0f, 0f);

    private bool animationComplete = false;

    void Start()
    {

    }

    public void OnAnimationComplete()
    {
        if (!animationComplete)
        {
            // Activate the new GameObjects from the list
            foreach (GameObject objToActivate in objectsToActivate)
            {
                if (objToActivate != null)
                {
                    objToActivate.SetActive(true);
                }
            }

            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }

            // Manipulate the object
            if (objectToManipulate != null)
            {
                objectToManipulate.position = desiredPosition;
                objectToManipulate.localRotation = Quaternion.Euler(desiredRotation);
                objectToManipulate.localScale = desiredScale;
            }

            animationComplete = true;
        }
    }
}