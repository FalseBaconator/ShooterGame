using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSense;
    public float mouseSenseGlobal;
    public Transform playerBody;

    private float xRot = 0f;
    private float mouseX;
    private float mouseY;

    public string OptionSaverTag;

    public GameObject TimerController;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (GameObject.FindGameObjectWithTag(OptionSaverTag) != null)
        {
            mouseSenseGlobal = GameObject.FindGameObjectWithTag(OptionSaverTag).GetComponent<OptionsSaver>().mouseSensitivity;
        }
        else
        {
            mouseSenseGlobal = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerController.GetComponent<TimeScript>().notYet == false)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSense * mouseSenseGlobal * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSense * mouseSenseGlobal * Time.deltaTime;

            xRot = xRot - mouseY;
            xRot = Mathf.Clamp(xRot, -90, 90);


            transform.localRotation = Quaternion.Euler(xRot, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
