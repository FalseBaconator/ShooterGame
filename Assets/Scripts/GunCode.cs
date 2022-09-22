using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCode : MonoBehaviour
{
    public float DMG;
    public float range;

    public Camera cam;
    public LayerMask targetMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, targetMask))
        {
            Destroy(hit.transform.gameObject);
        }
    }

}
