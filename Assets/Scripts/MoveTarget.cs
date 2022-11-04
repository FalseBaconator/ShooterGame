using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{

    public float speed;

    public ParticleSystem chunks;

    private void Awake()
    {
        gameObject.transform.parent = null;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            chunks.transform.parent = null;
            chunks.Play();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
