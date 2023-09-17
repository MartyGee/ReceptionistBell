using UnityEngine;
using System.Collections.Generic;

public class CoinCounter : MonoBehaviour
{
    public Collider goldCollider;
    public int requiredGoldCoins;
    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeactivate;

    private int totalGoldCoinsCollected = 0;
    private bool conditionMet = false;

    private void Update()
    {
        // Check the condition only if it's not already met
        if (!conditionMet)
        {
            if (totalGoldCoinsCollected >= requiredGoldCoins)
            {
                // Activate objects when the condition is met
                ActivateObjects(objectsToActivate);
                conditionMet = true;
            }
        }
        else
        {
            // Deactivate objects when the condition is no longer met
            if (totalGoldCoinsCollected < requiredGoldCoins)
            {
                DeactivateObjects(objectsToDeactivate);
                conditionMet = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check the tag of the entering object
        if (other.CompareTag("GoldCoin"))
        {
            totalGoldCoinsCollected++;
            // Send a debug message when a gold coin enters the collider
            Debug.Log("Gold Coin entered the collider.");
        }
    }

    private void ActivateObjects(List<GameObject> objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }

    private void DeactivateObjects(List<GameObject> objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
