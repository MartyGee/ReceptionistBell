using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    private PuzzleManager puzzleManager;

    [SerializeField]
    private int triggerPosition; // Specify the position of the trigger (1, 2, 3, or 4)

    private void Start()
    {
        // Find the PuzzleManager in the scene and register this trigger box
        puzzleManager = FindObjectOfType<PuzzleManager>();
        if (puzzleManager != null)
        {
            puzzleManager.RegisterTriggerBox(this);
        }
        else
        {
            Debug.LogError("PuzzleManager not found in the scene. Make sure it exists and is properly configured.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered trigger: " + other.tag);
        // Check if the object entering the trigger has a tag and notify the PuzzleManager
        string tagToCheck = other.tag;
        if (!string.IsNullOrEmpty(tagToCheck))
        {
            puzzleManager.TagEntered(this, tagToCheck, triggerPosition);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exited trigger: " + other.tag);
        // Check if the object exiting the trigger has a tag and notify the PuzzleManager
        string tagToCheck = other.tag;
        if (!string.IsNullOrEmpty(tagToCheck))
        {
            puzzleManager.TagExited(this, tagToCheck, triggerPosition);
        }
    }

}







