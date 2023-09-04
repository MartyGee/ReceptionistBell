using UnityEngine;

public class CabinetDeactivation : MonoBehaviour
{
    public Transform objectToManipulate; // Reference to the object you want to manipulate
    public GameObject objectToActivate1; // Reference to the GameObject to activate after animation finishes
    public GameObject objectToActivate2; // Reference to the GameObject to activate after animation finishes
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
            // Activate the new GameObject
            if (objectToActivate1 != null)
            {
                objectToActivate1.SetActive(true);
            }

            if (objectToActivate2 != null)
            {
                objectToActivate2.SetActive(true);
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