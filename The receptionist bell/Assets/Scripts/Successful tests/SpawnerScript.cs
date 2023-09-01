using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] public List<GameObject> objectsToSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (objectsToSpawn.Count > 0)
            {
                int randomIndex = Random.Range(0, objectsToSpawn.Count);
                GameObject objectPrefab = objectsToSpawn[randomIndex];

                // Generate a random rotation for the object
                Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

                // Instantiate the object with the random rotation
                Instantiate(objectPrefab, transform.position, randomRotation);
            }
        }
    }
}

