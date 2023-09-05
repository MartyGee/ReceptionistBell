using UnityEngine;

public class CabinetDoorAnimationScript : MonoBehaviour
{
    public Animator animator01; // Reference to the Animator component that plays the animation
    public Animator animator02;
    public AudioSource audioSource; // Reference to the AudioSource component for playing the sound

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has a specific tag (e.g., "Player")
        if (other.CompareTag("Player"))
        {
            // Trigger the animation by setting the "IsOpen" trigger in the Animator
            animator01.SetTrigger("IsOpen01");
            animator02.SetTrigger("IsOpen02");

            // Play the opening sound if an AudioSource and audio clip are set
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}