﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablePhysicsOnTap : MonoBehaviour
{
    private float width;
    private float height;
    private Vector3 StartPosition;
    private Vector3 CameraOffset;
    public GameObject FollowCamera;
    private Rigidbody m_Rigidbody;
    private bool wasTouched;
    

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        StartPosition = transform.position;
        CameraOffset.Set(0, -1, 3);
    }

    void Update()
    {
        FollowCamera.transform.position = transform.position - CameraOffset;
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            if (wasTouched == false)
            {
                //Touch touch = Input.GetTouch(0);
                print("test");
                m_Rigidbody.constraints = RigidbodyConstraints.None;
                transform.position = StartPosition;
                m_Rigidbody.velocity.Set(0, 0, 0);
                wasTouched = true;
            }
            else
            {
                wasTouched = false;
            }

        }
        else
        {
            wasTouched = true;
        }
        /*        else
                {
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                    transform.position = StartPosition;
                }*/
    }
}
