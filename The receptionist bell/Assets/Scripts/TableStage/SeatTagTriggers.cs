using UnityEngine;
using System.Collections.Generic;

public class SeatTagTriggers : MonoBehaviour
{
    public List<string> tagsToCheck = new List<string>(); // List of tags to check

    private void OnTriggerEnter(Collider other)
    {
        if (tagsToCheck.Contains(other.tag))
        {
            Debug.Log("Object with tag '" + other.tag + "' entered the collider.");
            // You can perform additional actions here.
        }
    }
}
