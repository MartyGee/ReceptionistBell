using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    private Dictionary<int, string> tagsByNumber = new Dictionary<int, string>();
    public List<string> validWords = new List<string>(); // Add other valid words here

    [Header("Word: BELL")]
    public AudioSource BellSound;
    public GameObject BELLpaper8;
    private bool bellSoundPlayed = false; // Flag to track if the "BELL" sound has been played

    [Header("Word: WELL")]
    public List<GameObject> objectsToActivateWELL;
    public List<GameObject> objectsToDeactivateWELL;

    [Header("Word: BOWL")]
    public List<GameObject> objectsToActivateBOWL;

    [Header("Word: BOWL")]
    public List<GameObject> objectsToActivateLOBE;

    // Register trigger boxes with the PuzzleManager
    public void RegisterTriggerBox(TriggerBox triggerBox)
    {
        // You can add any necessary logic here to handle registering trigger boxes if needed
    }

    //Enter the trigger
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

    //Exited the trigger
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

                if (formedWord == "BELL" && !bellSoundPlayed)
                {
                    PlayBellSound();
                    BELLpaper8.SetActive(true);
                    bellSoundPlayed = true; // Set the flag to true so that the sound won't play again
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

                if (formedWord == "LOBE")
                {
                    foreach (var obj in objectsToActivateLOBE)
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
        if (BellSound != null)
        {
            // Play the bell sound
            BellSound.Play();
        }
    }
}


















