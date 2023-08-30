using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Object;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Generate a random rotation for the object
            Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

            // Instantiate the object with the random rotation
            Instantiate(Object, transform.position, randomRotation);
        }
    }
}

