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
    public string targetTag;

    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    Animator anim;
    public ParticleSystem sparks;
    public ParticleSystem bullet;
    public GameObject hitEffect;

    public GameObject TimerController;

    public GameObject pauseObject;

    public AudioSource audSource;
    public AudioSource reloadSource;
    public AudioClip shootClip;
    public AudioClip explosion;

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

            bool isPaused = Pause.isPaused;

            if (Input.GetButtonDown("Fire1") && isPaused == false)
            {
                Shoot();
            }
            if (Input.GetButtonDown("Fire2") && isPaused == false)
            {
                Reload();
            }
            if(ammo == 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
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
            reloadSource.PlayDelayed(0.05f);
            ammo = fullAmmo;
            ammoText.text = "AMMO: " + ammo.ToString();
        }
    }

    void Shoot()
    {
        if (ammo > 0 && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            audSource.clip = shootClip;
            sparks.Play();
            bullet.Play();
            anim.SetTrigger("Fire");
            audSource.Play();
            ammo = ammo - 1;
            ammoText.text = "AMMO: " + ammo.ToString();

            RaycastHit[] hits = Physics.RaycastAll(cam.transform.position, cam.transform.forward, targetMask);
            if (hits.Length != 0)
            {
                foreach (RaycastHit hit in hits)
                {
                    if (hit.collider.gameObject.CompareTag(targetTag))
                    {
                        score = score + 1;
                        audSource.clip = explosion;
                        audSource.Play();
                        ParticleSystem chunks = hit.transform.gameObject.GetComponent<MoveTarget>().chunks;
                        chunks.transform.parent = null;
                        chunks.Play();
                        Destroy(hit.transform.gameObject);
                    }
                    GameObject effect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    //GameObject.Destroy(effect);
                }
                scoreText.text = "SCORE: " + score.ToString();
            }

        }
        
    }

}
