using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region Instance Variables
    [SerializeField]
    [Tooltip("The GameObject to follow")]
    private GameObject FollowObject = null;
    [SerializeField]
    private Vector3 Offset = Vector3.zero;
    [SerializeField]
    private bool ballNeedsToBeGrounded = true;
    #endregion

    private void Start()
    {
        transform.position = FollowObject.transform.position - Offset;
    }

    void Update()
    {
        if(FollowObject != null)
        {
            // for object that only follow the ball when its on the ground (camera)
            if(ballNeedsToBeGrounded && GameManager.onGround)
            {
                transform.position = FollowObject.transform.position - Offset;
            }
            else if(!ballNeedsToBeGrounded)
            {
                transform.position = FollowObject.transform.position - Offset;
            }
        }
    }
}
