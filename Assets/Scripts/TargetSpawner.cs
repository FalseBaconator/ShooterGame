using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    public GameObject[] spawnerLocations;
    public GameObject targetStationary;

    public string targetTag;
    public GameObject[] targets;


    public void OnTriggerEnter(Collider other)
    {
        targets = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject target in targets)
        {
            GameObject.Destroy(target);
        }
        foreach(GameObject spawner in spawnerLocations)
        {
            GameObject.Instantiate(targetStationary, spawner.transform);
        }
    }

}
