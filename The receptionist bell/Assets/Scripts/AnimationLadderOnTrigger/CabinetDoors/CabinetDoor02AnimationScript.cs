using UnityEngine;

public class CabinetDoor02AnimationScript : MonoBehaviour
{
    public Animator animator02; // Reference to the Animator component that plays the animation

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has a specific tag (e.g., "Player")
        if (other.CompareTag("Player"))
        {
            // Trigger the animation by setting the "IsOpen" trigger in the Animator
            animator02.SetTrigger("IsOpen02");
        }
    }
}
