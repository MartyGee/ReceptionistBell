using UnityEngine;
using System.Collections.Generic;

public class WellScript : MonoBehaviour
{
    // Create an array of tags you want to check for.
    public string[] targetTags = { "CopperCoin", "SilverCoin", "GoldCoin" };

    // Lists of objects to activate based on the number of tags entered.
    public GameObject PaperSmooth8WELL;
    [Space]
    public List<GameObject> objectsToActivate1;
    public List<GameObject> objectsToActivate2;
    public List<GameObject> objectsToActivate3;

    

    private int tagsEntered = 0;

    private void OnTriggerEnter(Collider other)
    {
        foreach (string tag in targetTags)
        {
            if (other.CompareTag(tag))
            {
                Debug.Log("Object with tag '" + tag + "' entered the trigger.");

                // Deactivate the previously activated list of objects.
                DeactivatePreviousList();

                // Increase the count of tags entered.
                tagsEntered++;

                // Activate the corresponding list of objects based on the number of tags entered.
                switch (tagsEntered)
                {
                    case 1:
                        ActivateObjects(objectsToActivate1);
                        PaperSmooth8WELL.SetActive(false);
                        break;
                    case 2:
                        ActivateObjects(objectsToActivate2);
                        break;
                    case 3:
                        ActivateObjects(objectsToActivate3);
                        break;
                }

                // Stop at 3 tags entered.
                if (tagsEntered >= 3)
                {
                    tagsEntered = 3;
                }
            }
        }
    }

    // Helper method to activate a list of objects.
    private void ActivateObjects(List<GameObject> objectList)
    {
        foreach (GameObject obj in objectList)
        {
            obj.SetActive(true);
        }
    }

    // Helper method to deactivate the previously activated list of objects.
    private void DeactivatePreviousList()
    {
        switch (tagsEntered)
        {
            case 1:
                DeactivateObjects(objectsToActivate1);
                break;
            case 2:
                DeactivateObjects(objectsToActivate2);
                break;
        }
    }

    // Helper method to deactivate a list of objects.
    private void DeactivateObjects(List<GameObject> objectList)
    {
        foreach (GameObject obj in objectList)
        {
            obj.SetActive(false);
        }
    }
}

