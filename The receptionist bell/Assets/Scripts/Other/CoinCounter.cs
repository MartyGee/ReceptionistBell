using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int requiredObjectsCount = 7; // Set the number of required objects
    private int enteredCount = 0;

    public GameObject[] objectsToActivate; // List of objects to activate
    public GameObject[] objectsToDeactivate; // List of objects to deactivate

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoldCoin"))
        {
            enteredCount++;
            Debug.Log("GoldCoin entered the collider.");

            if (enteredCount == requiredObjectsCount)
            {
                Debug.Log("All 7 GoldCoins have entered the collider.");

                // Activate objects
                foreach (var obj in objectsToActivate)
                {
                    obj.SetActive(true);
                }

                // Deactivate objects
                foreach (var obj in objectsToDeactivate)
                {
                    obj.SetActive(false);
                }

                // You can add any other desired actions or logic here.
            }
        }
    }

    // Optionally, you can reset the count when GoldCoins exit.
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GoldCoin"))
        {
            enteredCount--;
            Debug.Log("GoldCoin exited the collider.");

            if (enteredCount < 0)
            {
                enteredCount = 0;
            }
        }
    }
}

