using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    #region MemberVariables
    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    //private float animationDuration = 2.0f;
    #endregion

    #region Start
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    #endregion

    #region Update
    void Update()
    {
        //if(Time.time < animationDuration)
        //{
        //    controller.Move(Vector3.forward * speed * Time.deltaTime);
        //    return;
        //}

        moveVector = Vector3.zero;

        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }
    #endregion
}
