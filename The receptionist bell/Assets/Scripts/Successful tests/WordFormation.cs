using UnityEngine;
using System.Collections.Generic;

public class WordFormation : MonoBehaviour
{
    public AudioSource sound; // Audio source to play when "BELL" is formed
    private List<string> currentWord = new List<string>();
    private string targetWord = "BELL"; // The target word to form

    private int currentColliderIndex = 0; // Index of the current collider (starts at 0)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("E") || other.CompareTag("B") || other.CompareTag("L"))
        {
            // Check if the collider entered is the next expected collider in the sequence
            if (ColliderMatchesExpected(other))
            {
                currentWord.Add(other.tag);
                currentColliderIndex++;
                CheckWordFormation();
            }
            else
            {
                // Reset if an incorrect collider is entered
                ResetWordFormation();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("E") || other.CompareTag("B") || other.CompareTag("L"))
        {
            currentWord.Remove(other.tag);
            currentColliderIndex--;
        }
    }

    private bool ColliderMatchesExpected(Collider collider)
    {
        // Check if the entered collider matches the expected collider in the sequence
        switch (currentColliderIndex)
        {
            case 0:
                return collider.CompareTag("B");
            case 1:
                return collider.CompareTag("E");
            case 2:
                return collider.CompareTag("L");
            case 3:
                return collider.CompareTag("L");
            default:
                return false;
        }
    }

    private void CheckWordFormation()
    {
        // Check if the word is fully formed (all letters in order)
        if (currentWord.Count == targetWord.Length)
        {
            string formedWord = string.Join("", currentWord);
            if (formedWord == targetWord)
            {
                sound.Play();
                Debug.Log("Word 'BELL' Formed!");
            }
            else
            {
                Debug.Log("Word Formed: " + formedWord);
            }
        }
    }

    private void ResetWordFormation()
    {
        currentWord.Clear();
        currentColliderIndex = 0;
    }
}