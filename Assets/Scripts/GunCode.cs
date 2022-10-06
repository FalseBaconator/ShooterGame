using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunCode : MonoBehaviour
{
    public float DMG;
    public float range;
    public int fullAmmo;
    public int ammo;

    public Camera cam;
    public LayerMask targetMask;

    int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    Animator anim;


    private void Start()
    {
        score = 0;
        scoreText.text = "SCORE: " + score.ToString();
        ammoText.text = "AMMO: " + ammo.ToString();
        ammo = fullAmmo;
        anim = GetComponent<Animator>();
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
        ammo = fullAmmo;
        ammoText.text = "AMMO: " + ammo.ToString();
    }

    void Shoot()
    {
        if (ammo > 0)
        {
            anim.SetTrigger("Fire");
            ammo = ammo - 1;
            ammoText.text = "AMMO: " + ammo.ToString();

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
