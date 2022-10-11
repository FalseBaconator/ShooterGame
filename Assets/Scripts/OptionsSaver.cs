using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsSaver : MonoBehaviour
{
    public float mouseSensitivity;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        mouseSensitivity = 1;
    }

    public void ChangeMouseSensitivity(float Sense)
    {
        mouseSensitivity = Sense;
    }
}
