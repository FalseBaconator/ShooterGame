using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowSensitivity : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void DisplaySense(float num)
    {
        text.text = "Mouse Sensitivity: " + num.ToString("0.0");
    }
}
