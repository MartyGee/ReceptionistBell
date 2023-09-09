using UnityEngine;

public class TagSum : MonoBehaviour
{
    private string tagSum = "";
    public AudioSource bellSound; // Reference to the AudioSource component

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has one of the specified tags
        if (IsTagAllowed(other.tag))
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

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has one of the specified tags
        if (IsTagAllowed(other.tag))
        {
            // Remove the exiting tag from the current tagSum
            tagSum = tagSum.Replace(other.tag, "");

            // Log the current tag sum
            Debug.Log("Tag Sum: " + tagSum);
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

    // Check if a tag is one of the specified allowed tags
    private bool IsTagAllowed(string tag)
    {
        return (tag == "W" || tag == "O" || tag == "B" || tag == "E" || tag == "L");
    }
}
