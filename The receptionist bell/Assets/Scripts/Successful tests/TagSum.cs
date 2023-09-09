using UnityEngine;

public class TagSum : MonoBehaviour
{
    private char[] letterArray = new char[5]; // Array to store the letters
    public AudioSource audioSource; // Public reference to the AudioSource component

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has one of the specified tags
        if (IsTagAllowed(other.tag))
        {
            // Determine the insertion index based on the order of insertion
            int insertIndex = FindInsertIndex();

            // Add the letter to the array at the determined index
            letterArray = InsertLetter(letterArray, other.tag[0], insertIndex);

            // Log the current letter array
            Debug.Log("Letter Array: " + new string(letterArray));

            // Check if the accumulated letters equal "BELL"
            if (new string(letterArray) == "BELL")
            {
                // Play the sound from the assigned AudioSource component
                PlayBellSound();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has one of the specified tags
        if (IsTagAllowed(other.tag))
        {
            // Find the index of the letter to remove from the array
            int indexToRemove = System.Array.IndexOf(letterArray, other.tag[0]);

            if (indexToRemove != -1)
            {
                // Remove the letter from the array
                letterArray = RemoveLetter(letterArray, indexToRemove);

                // Log the current letter array
                Debug.Log("Letter Array: " + new string(letterArray));
            }
        }
    }

    private void PlayBellSound()
    {
        // Check if the AudioSource component is not null
        if (audioSource != null)
        {
            // Play the sound from the assigned AudioSource component
            audioSource.Play();
        }
    }

    // Check if a tag is one of the specified allowed tags
    private bool IsTagAllowed(string tag)
    {
        return (tag == "W" || tag == "O" || tag == "B" || tag == "E" || tag == "L");
    }

    // Insert a letter into the letterArray at the specified index
    private char[] InsertLetter(char[] array, char letter, int index)
    {
        char[] newArray = new char[array.Length + 1];
        for (int i = 0; i < newArray.Length; i++)
        {
            if (i < index)
            {
                newArray[i] = array[i];
            }
            else if (i == index)
            {
                newArray[i] = letter;
            }
            else
            {
                newArray[i] = array[i - 1];
            }
        }
        return newArray;
    }

    // Remove a letter from the letterArray at the specified index
    private char[] RemoveLetter(char[] array, int index)
    {
        char[] newArray = new char[array.Length - 1];
        for (int i = 0; i < newArray.Length; i++)
        {
            if (i < index)
            {
                newArray[i] = array[i];
            }
            else
            {
                newArray[i] = array[i + 1];
            }
        }
        return newArray;
    }

    // Find the insertion index based on the order of insertion
    private int FindInsertIndex()
    {
        for (int i = 0; i < letterArray.Length; i++)
        {
            if (letterArray[i] == '\0')
            {
                return i;
            }
        }
        return letterArray.Length;
    }
}

