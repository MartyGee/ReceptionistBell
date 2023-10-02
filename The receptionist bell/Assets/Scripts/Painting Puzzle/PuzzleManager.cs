using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    private Dictionary<int, string> tagsByPosition = new Dictionary<int, string>();
    public List<string> validWords = new List<string>(); // Add other valid words here

    [Header("Word: BELL")]
    public AudioSource BellSound;
    public GameObject BELLpaper8;

    [Header("Word: WELL")]
    public List<GameObject> objectsToActivate; // List of objects to activate
    public List<GameObject> objectsToDeactivate; // List of objects to activate



    // Register trigger boxes with the PuzzleManager
    public void RegisterTriggerBox(TriggerBox triggerBox)
    {
        // You can add any necessary logic here to handle registering trigger boxes if needed
    }

    // Handle a tag entering the trigger
    public void TagEntered(TriggerBox triggerBox, string tag, int triggerPosition)
    {
        Debug.Log("Tag Entered: " + tag + " at position " + triggerPosition);

        // Check if the tag is valid (not empty or "Untagged") and store it based on trigger position
        if (!string.IsNullOrEmpty(tag) && tag != "Untagged")
        {
            tagsByPosition[triggerPosition] = tag;
            CheckWordFormation();
        }
    }

    // Handle a tag exiting the trigger
    public void TagExited(TriggerBox triggerBox, string tag, int triggerPosition)
    {
        Debug.Log("Tag Exited: " + tag + " from position " + triggerPosition);

        // Check if the tag is valid (not empty or "Untagged") and remove it based on trigger position
        if (!string.IsNullOrEmpty(tag) && tag != "Untagged")
        {
            tagsByPosition.Remove(triggerPosition);
            CheckWordFormation();
        }
    }

    private void CheckWordFormation()
    {
        // Debug log statement to print dictionary contents
        foreach (var kvp in tagsByPosition)
        {
            Debug.Log("Trigger Position: " + kvp.Key + ", Tag: " + kvp.Value);
        }

        // Check if the tags of the triggers form any valid words
        foreach (string word in validWords)
        {
            bool wordFormed = true;
            string formedWord = "";

            for (int i = 1; i <= 4; i++)
            {
                if (!tagsByPosition.ContainsKey(i) || tagsByPosition[i] != word[i - 1].ToString())
                {
                    wordFormed = false;
                    break;
                }
                formedWord += tagsByPosition[i];
            }

            if (wordFormed)
            {
                Debug.Log("Word formed: " + formedWord);

                if (formedWord == "BELL")
                {
                    PlayBellSound();
                    BELLpaper8.SetActive(true);
                }
                else if (formedWord == "WELL")
                {
                    // Activate a list of objects
                    foreach (var obj in objectsToActivate)
                    {
                        obj.SetActive(true);
                    }

                    // Activate a list of objects
                    foreach (var obj in objectsToDeactivate)
                    {
                        obj.SetActive(false);
                    }
                }

                ClearTags();
                break;
            }
        }
    }

    private void PlayBellSound()
    {
        // Check if the AudioSource component is not null
        if (BellSound != null)
        {
            // Play the bell sound
            BellSound.Play();
        }
    }

    private void ClearTags()
    {
        tagsByPosition.Clear();
    }
}


















