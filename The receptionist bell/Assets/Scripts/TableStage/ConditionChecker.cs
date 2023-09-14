using UnityEngine;
using System.Collections.Generic;

public class ConditionChecker : MonoBehaviour
{
    public List<string> requiredTagsForPhase1 = new List<string>(); // List of tags to check for Phase 1
    public List<string> requiredTagsForPhase2 = new List<string>(); // List of tags to check for Phase 2
    private Dictionary<string, int> tagCount = new Dictionary<string, int>(); // Dictionary to count the number of objects with each tag
    private bool phase1ConditionsMet = false;
    private bool phase2ConditionsMet = false;

    public List<GameObject> GuestsColliders;
    public List<GameObject> ObjectsToActivate; // List of objects to activate when conditions are met
    public List<GameObject> ObjectsToDeactivate; // List of objects to deactivate when conditions are met

    private bool guestsCollidersActivated = false; // Flag to track if GuestsColliders are activated

    private void Start()
    {
        DeactivateObjects();
    }

    public void ObjectEntered(string tag)
    {
        if (!tagCount.ContainsKey(tag))
        {
            tagCount[tag] = 1;
        }
        else
        {
            tagCount[tag]++;
        }

        CheckConditions();
    }

    public void ObjectExited(string tag)
    {
        if (tagCount.ContainsKey(tag))
        {
            tagCount[tag]--;
            if (tagCount[tag] <= 0)
            {
                tagCount.Remove(tag);
            }
        }

        CheckConditions();
    }

    // Check if Phase 1 conditions are met
    public bool ArePhase1ConditionsMet()
    {
        foreach (string requiredTag in requiredTagsForPhase1)
        {
            if (!tagCount.ContainsKey(requiredTag) || tagCount[requiredTag] <= 0)
            {
                return false;
            }
        }
        return true;
    }

    // Check if Phase 2 conditions are met
    public bool ArePhase2ConditionsMet()
    {
        int count = 0;
        foreach (string requiredTag in requiredTagsForPhase2)
        {
            if (tagCount.ContainsKey(requiredTag))
            {
                count += tagCount[requiredTag];
            }
        }
        return count >= 8; // Require at least two objects with the specified tags for Phase 2
    }

    // Check conditions and activate/deactivate objects if both Phase 1 and Phase 2 conditions are met
    public void CheckConditions()
    {
        // Check Phase 1 conditions
        if (ArePhase1ConditionsMet())
        {
            phase1ConditionsMet = true;
        }
        else
        {
            phase1ConditionsMet = false;
        }

        // If GuestsColliders are not yet activated and Phase 1 conditions are met, activate them
        if (!guestsCollidersActivated && phase1ConditionsMet)
        {
            ActivateObjectsFromList(GuestsColliders);
            guestsCollidersActivated = true;
        }

        // Check Phase 2 conditions
        if (ArePhase2ConditionsMet())
        {
            phase2ConditionsMet = true;
        }
        else
        {
            phase2ConditionsMet = false;
        }

        // Activate objects from the ObjectsToActivate list and deactivate objects from the ObjectsToDeactivate list
        if (phase1ConditionsMet && phase2ConditionsMet)
        {
            Debug.Log("Both Phase 1 and Phase 2 conditions are met. Activating and deactivating objects.");
            ActivateObjectsFromList(ObjectsToActivate);
            DeactivateObjectsFromList(ObjectsToDeactivate);
        }
    }

    // Activate a list of objects
    private void ActivateObjectsFromList(List<GameObject> objectsToActivate)
    {
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    // Deactivate a list of objects
    private void DeactivateObjectsFromList(List<GameObject> objectsToDeactivate)
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    // Deactivate all objects
    private void DeactivateObjects()
    {
        DeactivateObjectsFromList(GuestsColliders);
        DeactivateObjectsFromList(ObjectsToActivate);
    }
}



