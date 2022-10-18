using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float maxTime;
    float timer;
    public GameObject scoreHolder;
    public int score;

    private static GameObject existCheck;

    private void Awake()
    {
        if (existCheck != null)
        {
            Destroy(existCheck);
        }

        existCheck = gameObject;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(gameObject);
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("00");
        }else if (timer < 0)
        {
            timer = 0;
            timerText.text = timer.ToString("00");
            score = scoreHolder.GetComponent<GunCode>().score;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
