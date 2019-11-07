using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePhysicsOnTap : MonoBehaviour
{

    #region Instance Variables
    [SerializeField]
    [Tooltip("The camera to follow the game object")]
    private GameObject FollowCamera = null;
    #endregion

    #region Hidden Variables
    private float width;
    private float height;
    private Vector3 StartPosition;
    private Vector3 CameraOffset;
    private Rigidbody m_Rigidbody;
    private bool wasTouched;
    #endregion

    void Awake()
    {
        if (this.enabled)
        {
            width = (float)Screen.width / 2.0f;
            height = (float)Screen.height / 2.0f;
            m_Rigidbody = this.gameObject.GetComponent<Rigidbody>();
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            StartPosition = this.gameObject.transform.position;
            CameraOffset.Set(0, -1, 6);
        }
    }

    void Update()
    {
        FollowCamera.transform.position = transform.position - CameraOffset;
        // Handle screen touches.
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            if (wasTouched == false)
            {
                //Touch touch = Input.GetTouch(0);
                m_Rigidbody.constraints = RigidbodyConstraints.None;
                this.gameObject.transform.position = StartPosition;
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

