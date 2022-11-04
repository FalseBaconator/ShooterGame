using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCannon : MonoBehaviour
{

    public float timeMin;
    public float timeMax;
    float timer;

    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(timeMin, timeMax);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(timeMin, timeMax);
            GameObject.Instantiate(target, gameObject.transform);
        }
    }
}
