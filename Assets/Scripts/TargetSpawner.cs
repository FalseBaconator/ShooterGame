using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    public GameObject[] spawnerLocations;
    public GameObject targetStationary;

    public string targetTag;


    public void OnTriggerEnter(Collider other)
    {
        if(GameObject.FindGameObjectWithTag(targetTag) == null)
        {
            foreach (GameObject spawner in spawnerLocations)
            {
                GameObject.Instantiate(targetStationary, spawner.transform);
            }
        }
    }

}
