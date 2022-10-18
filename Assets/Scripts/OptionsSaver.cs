using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsSaver : MonoBehaviour
{
    public float mouseSensitivity;

    private static GameObject existCheck;

    public void Awake()
    {
        if (existCheck != null)
        {
            Destroy(existCheck);
        }

        existCheck = gameObject;
        DontDestroyOnLoad(gameObject);
        mouseSensitivity = 1;
    }

    public void ChangeMouseSensitivity(float Sense)
    {
        mouseSensitivity = Sense;
    }
}
