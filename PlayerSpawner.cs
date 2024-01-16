using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject prefabToInstantiate;

    void Start()
    {
        // Check if the prefab already exists in the scene
        GameObject existingPrefab = GameObject.Find("Player");

        if (existingPrefab == null)
        {
            // Instantiate the prefab if it doesn't exist
            Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
        }
        else
        {
            // The prefab already exists in the scene
            Debug.Log("Prefab already exists in the scene.");
        }
    }
}
