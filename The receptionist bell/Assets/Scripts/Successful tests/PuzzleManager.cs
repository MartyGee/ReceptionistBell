using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    private Dictionary<int, string> tagsByPosition = new Dictionary<int, string>();
    public List<string> validWords = new List<string>(); // Add other valid words here

    [Header("Word: BELL")]
    public AudioSource audioSource; 

    [Header("Word: WELL")]
    public GameObject TestObject;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();
    }

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

                // Play the audio when "BELL" is formed
                if (formedWord == "BELL")
                {
                    audioSource.Play();
                }

                else if (formedWord == "WELL")
                {
                    TestObject.SetActive(true);
                }

                ClearTags();
                break;
            }
        }
    }

    private void ClearTags()
    {
        tagsByPosition.Clear();
    }
}

















