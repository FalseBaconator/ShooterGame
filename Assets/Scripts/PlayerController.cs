using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity;

    float X;
    float Z;

    Vector3 Move;
    Vector3 Vel;

    public CharacterController Cont;

    // Update is called once per frame
    void Update()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        Move = transform.right * X + transform.forward * Z;
        Cont.Move(Move * speed * Time.deltaTime);

        Vel.y += gravity * Time.deltaTime;
        Cont.Move(Vel * Time.deltaTime);

    }
}
