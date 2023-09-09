using UnityEngine;
using System.Collections.Generic;

public class testWord : MonoBehaviour
{
    public List<string> targetTags = new List<string>(); // Specify the tags you want to check for in the Inspector
    private List<string> enteredTags = new List<string>(); // Keep track of entered tags

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has any of the specified tags
        if (targetTags.Contains(other.tag))
        {
            // Add the entered tag to the list
            enteredTags.Add(other.tag);
            Debug.Log("Object with tag '" + other.tag + "' entered the trigger.");
        }
    }
}