using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSense;
    public Transform playerBody;

    private float xRot = 0f;
    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xRot = xRot - mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);


        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
