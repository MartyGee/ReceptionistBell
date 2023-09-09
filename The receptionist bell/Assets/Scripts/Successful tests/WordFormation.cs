using UnityEngine;
using System.Collections.Generic;

public class WordFormation : MonoBehaviour
{
    public AudioSource audioSource; // Assign the AudioSource for playing the sound in the Inspector

    private Dictionary<string, int> letterValues = new Dictionary<string, int>
    {
        { "B", 1 },
        { "E", 2 },
        { "L", 3 }
    };

    private int targetSum = 9; // The target sum for the word "BELL"
    private int currentSum = 0; // Stores the current sum of assigned numbers

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has a tag mapped in the dictionary
        if (letterValues.ContainsKey(other.tag))
        {
            currentSum += letterValues[other.tag];
        }

        // Check if the current sum matches the target sum
        if (currentSum == targetSum)
        {
            Debug.Log("Word 'BELL' has been formed!");
            // Play the sound when the word is formed
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}