using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI readySetText;
    public int currentScene;
    public int loadScene;

    public float maxTime;
    float timer;
    public float readySetMax;
    float readySetGo;
    public bool notYet = true;
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
        timer = maxTime;
        readySetGo = readySetMax;

        timerText.text = timer.ToString("00");
        readySetText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(notYet == false)
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
                currentScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(loadScene);
            }
        }else if(readySetGo > 0)
        {
            readySetGo -= Time.deltaTime;
            readySetText.text = readySetGo.ToString("0");
        }else
        {
            readySetGo = 0;
            notYet = false;
            readySetText.gameObject.SetActive(false);
        }

    }
}
