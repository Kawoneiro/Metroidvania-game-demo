using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public Movement movement;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        movement.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

}