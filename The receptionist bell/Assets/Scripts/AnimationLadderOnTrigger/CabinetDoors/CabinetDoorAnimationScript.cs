using UnityEngine;

public class CabinetDoorAnimationScript : MonoBehaviour
{
    public Animator animator01; // Reference to the Animator component that plays the animation
    public Animator animator02;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has a specific tag (e.g., "Player")
        if (other.CompareTag("Player"))
        {
            // Trigger the animation by setting the "IsOpen" trigger in the Animator
            animator01.SetTrigger("IsOpen01");
            animator02.SetTrigger("IsOpen02");
        }
    }
}