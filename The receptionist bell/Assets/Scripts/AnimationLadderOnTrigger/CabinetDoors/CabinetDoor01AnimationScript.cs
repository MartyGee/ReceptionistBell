using UnityEngine;

public class CabinetDoor01AnimationScript : MonoBehaviour
{
    public Animator animator01; // Reference to the Animator component that plays the animation

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has a specific tag (e.g., "Player")
        if (other.CompareTag("Player"))
        {
            // Trigger the animation by setting the "IsOpen" trigger in the Animator
            animator01.SetTrigger("IsOpen01");
        }
    }
}