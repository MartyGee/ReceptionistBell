using UnityEngine;

public class SeatTagTriggers : MonoBehaviour
{
    public string tagToCheck; // The tag to check for this object

    private ConditionChecker conditionChecker;
    private bool phase1Met = false; // Flag to track Phase 1 condition

    private void Start()
    {
        // Find the ConditionChecker in the scene
        conditionChecker = GameObject.FindObjectOfType<ConditionChecker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            Debug.Log("Object with tag '" + tagToCheck + "' entered the collider.");
            // You can perform additional actions here.

            // Notify the ConditionChecker that this condition is met for Phase 1
            conditionChecker.ObjectEntered(tagToCheck);

            // Check Phase 1 conditions
            if (!phase1Met && conditionChecker.ArePhase1ConditionsMet())
            {
                Debug.Log("Phase 1 conditions are met.");
                phase1Met = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            Debug.Log("Object with tag '" + tagToCheck + "' exited the collider.");
            // You can perform additional actions here.

            // Notify the ConditionChecker that this condition is no longer met for Phase 1
            conditionChecker.ObjectExited(tagToCheck);

            // Check Phase 1 conditions
            if (phase1Met && !conditionChecker.ArePhase1ConditionsMet())
            {
                Debug.Log("Phase 1 conditions are not met.");
                phase1Met = false;
            }
        }
    }
}

