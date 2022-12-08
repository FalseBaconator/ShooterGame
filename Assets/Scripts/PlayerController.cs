using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpHeight;

    float X;
    float Z;

    Vector3 Move;
    public Vector3 Vel;

    public CharacterController Cont;
    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;

    bool isGrounded;

    public GameObject timerController;

    private void Awake()
    {
        gameObject.transform.position = new Vector3(0, 1.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerController.GetComponent<TimeScript>().notYet == false)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

            if (isGrounded && Vel.y < 0)
            {
                Vel.y = -2f;
            }

            X = Input.GetAxisRaw("Horizontal");
            Z = Input.GetAxisRaw("Vertical");

            Move = (transform.right * X + transform.forward * Z).normalized;
            Cont.Move(Move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Vel.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }


            Vel.y += gravity * Time.deltaTime;
            Cont.Move(Vel * Time.deltaTime);
        }

    }
}
