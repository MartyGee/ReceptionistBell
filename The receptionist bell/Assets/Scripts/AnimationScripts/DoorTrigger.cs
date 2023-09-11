using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator = null; // Reference to the Animator component.
    public string animationTrigger = "DoorTrigger"; // Trigger for the second animation.

    private void DoorTriggerVoid(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger animation.
            doorAnimator.SetTrigger(animationTrigger);
        }
    }
}