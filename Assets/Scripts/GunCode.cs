using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunCode : MonoBehaviour
{
    public float DMG;
    public float range;
    public int FullAmmo;
    public int Ammo;

    public Camera cam;
    public LayerMask targetMask;

    int score;
    public TextMeshProUGUI scoreText;


    private void Start()
    {
        score = 0;
        scoreText.text = "SCORE: " + score.ToString();
        Ammo = FullAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Reload();
        }
    }

    void Reload()
    {
        Ammo = FullAmmo;
    }

    void Shoot()
    {
        if (Ammo > 0)
        {
            Ammo = Ammo - 1;
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, targetMask))
            {
                score = score + 1;
                scoreText.text = "SCORE: " + score.ToString();
                Destroy(hit.transform.gameObject);
            }

        }
        
    }

}
