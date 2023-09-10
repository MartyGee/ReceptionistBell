using UnityEngine;
using System.Collections.Generic;

public class ObjectTagChecker : MonoBehaviour
{
    public int requiredObjectCount = 2; // The number of objects required in each collider
    private Dictionary<string, int> tagCounts = new Dictionary<string, int>();

    private void Awake()
    {
        // Initialize the tagCounts dictionary for all tags you want to track
        string[] tagsToCheck = { "Tag1", "Tag2", "Tag3", "Tag4" };
        foreach (string tag in tagsToCheck)
        {
            tagCounts[tag] = 0;
        }
    }

    public void ObjectEntered(string tag)
    {
        if (tagCounts.ContainsKey(tag))
        {
            tagCounts[tag]++;
            CheckCompletion();
        }
    }

    public void ObjectExited(string tag)
    {
        if (tagCounts.ContainsKey(tag))
        {
            tagCounts[tag]--;
        }
    }

    private void CheckCompletion()
    {
        bool allComplete = true;
        foreach (string tag in tagCounts.Keys)
        {
            if (tagCounts[tag] != requiredObjectCount)
            {
                allComplete = false;
                break;
            }
        }

        if (allComplete)
        {
            Debug.Log("Yay we made it");
        }
    }
}
