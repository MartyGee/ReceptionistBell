using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    private Dictionary<int, string> tagsByNumber = new Dictionary<int, string>();
    public List<string> validWords = new List<string>(); // Add other valid words here

    [Header("Word: BELL")]
    public AudioSource BellSound;
    public GameObject BELLpaper8;

    [Header("Word: WELL")]
    public List<GameObject> objectsToActivateWELL; 
    public List<GameObject> objectsToDeactivateWELL; 

    [Header("Word: BOWL")]
    public List<GameObject> objectsToActivateBOWL; 


    // Register trigger boxes with the PuzzleManager
    public void RegisterTriggerBox(TriggerBox triggerBox)
    {
        // You can add any necessary logic here to handle registering trigger boxes if needed
    }

    // Handle a tag entering the trigger
    public void TagEntered(TriggerBox triggerBox, string tag, int triggerNumber)
    {
        Debug.Log("Tag Entered: " + tag + " at number " + triggerNumber);

        // Check if the tag is valid (not empty or "Untagged") and store it based on trigger position
        if (!string.IsNullOrEmpty(tag) && tag != "Untagged")
        {
            tagsByNumber[triggerNumber] = tag;
            CheckWordFormation();
        }
    }

    // Handle a tag exiting the trigger
    public void TagExited(TriggerBox triggerBox, string tag, int triggerNumber)
    {
        Debug.Log("Tag Exited: " + tag + " from number " + triggerNumber);

        // Check if the tag is valid (not empty or "Untagged") and remove it based on trigger position
        if (!string.IsNullOrEmpty(tag) && tag != "Untagged")
        {
            tagsByNumber.Remove(triggerNumber);
            CheckWordFormation();
        }
    }

    private void CheckWordFormation()
    {
        // Check if the tags of the triggers form any valid words
        foreach (string word in validWords)
        {
            bool wordFormed = true;
            string formedWord = "";

            for (int i = 1; i <= 4; i++)
            {
                if (!tagsByNumber.ContainsKey(i))
                {
                    wordFormed = false;
                    break;
                }

                string tag = tagsByNumber[i];

                if (tag != null && i <= word.Length && tag != word[i - 1].ToString())
                {
                    wordFormed = false;
                    break;
                }

                formedWord += tag;
            }

            if (wordFormed)
            {
                Debug.Log("Word formed: " + formedWord);

                if (formedWord == "BELL")
                {
                    PlayBellSound();
                    BELLpaper8.SetActive(true);
                }

                if (formedWord == "WELL")
                {
                    foreach (var obj in objectsToActivateWELL)
                    {
                        obj.SetActive(true);
                    }

                    foreach (var obj in objectsToDeactivateWELL)
                    {
                        obj.SetActive(false);
                    }
                }

                if (formedWord == "BOWL")
                {
                    foreach (var obj in objectsToActivateBOWL)
                    {
                        obj.SetActive(true);
                    }
                }

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
}


















