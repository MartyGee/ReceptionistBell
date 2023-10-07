using UnityEngine;

public class ObjectsTagTrigger : MonoBehaviour
{
    public string tagToCheck; // The tag to check for this object
    public int requiredObjectCount = 2; // The number of objects with the specified tag required to meet conditions

    private int objectsEnteredCount = 0;
    private ConditionChecker conditionChecker;
    private bool phase2Met = false; // Flag to track Phase 2 condition

    private void Start()
    {
        // Find the ConditionChecker in the scene
        conditionChecker = GameObject.FindObjectOfType<ConditionChecker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            objectsEnteredCount++;
            Debug.Log("Object with tag '" + tagToCheck + "' entered the collider. Count: " + objectsEnteredCount);

            // Notify the ConditionChecker that an object entered
            conditionChecker.ObjectEntered(tagToCheck);

            // Check Phase 2 conditions
            if (!phase2Met)
            {
                if (objectsEnteredCount >= requiredObjectCount)
                {
                    Debug.Log("Phase 2 conditions are met.");
                    phase2Met = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            objectsEnteredCount--;
            Debug.Log("Object with tag '" + tagToCheck + "' exited the collider. Count: " + objectsEnteredCount);

            // Notify the ConditionChecker that an object exited
            conditionChecker.ObjectExited(tagToCheck);

            // Check Phase 2 conditions
            if (phase2Met)
            {
                if (objectsEnteredCount < requiredObjectCount)
                {
                    Debug.Log("Phase 2 conditions are not met.");
                    phase2Met = false;
                }
            }
        }
    }
}


