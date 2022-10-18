using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float maxTime;
    float timer;

    private void Start()
    {
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
        }
    }
}
