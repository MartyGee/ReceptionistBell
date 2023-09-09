using UnityEngine;

public class TagSum : MonoBehaviour
{
    private string tagSum = "";
    public AudioSource bellSound; // Reference to the AudioSource component

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has one of the specified tags
        if (other.CompareTag("W") || other.CompareTag("O") || other.CompareTag("B") || other.CompareTag("E") || other.CompareTag("L"))
        {
            // Append the tag to the current tagSum
            tagSum += other.tag;

            // Log the current tag sum
            Debug.Log("Tag Sum: " + tagSum);

            // Check if the accumulated tag sum equals "BELL"
            if (tagSum == "BELL")
            {
                // Play the bell sound
                PlayBellSound();
            }
        }
    }

    private void PlayBellSound()
    {
        // Check if the AudioSource component is not null
        if (bellSound != null)
        {
            // Play the bell sound
            bellSound.Play();
        }
    }
}