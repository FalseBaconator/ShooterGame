using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunCode : MonoBehaviour
{
    public float DMG;
    public float range;

    public Camera cam;
    public LayerMask targetMask;

    int score;
    public TextMeshProUGUI scoreText;


    private void Start()
    {
        score = 0;
        scoreText.text = "SCORE: " + score.ToString();
    }

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
            score = score + 1;
            scoreText.text = "SCORE: " + score.ToString();
            Destroy(hit.transform.gameObject);
        }
    }

}
