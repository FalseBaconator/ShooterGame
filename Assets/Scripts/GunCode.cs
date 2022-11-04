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

    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    Animator anim;
    public ParticleSystem sparks;

    public GameObject TimerController;


    private void Start()
    {
        score = 0;
        ammo = fullAmmo;
        scoreText.text = "SCORE: " + score.ToString();
        ammoText.text = "AMMO: " + ammo.ToString();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerController.GetComponent<TimeScript>().notYet == false)
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
    }

    void Reload()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && ammo < fullAmmo)
        {
            anim.SetTrigger("Reload");
            ammo = fullAmmo;
            ammoText.text = "AMMO: " + ammo.ToString();
        }
    }

    void Shoot()
    {
        if (ammo > 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            sparks.Play();
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

        }else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            //empty gun click
        }
        
    }

}
