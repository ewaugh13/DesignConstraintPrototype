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
    #endregion

    #region Hidden Variables
    private PlayerCollision playerCollision = null;
    #endregion

    private void Start()
    {
        playerCollision = FollowObject.GetComponent<PlayerCollision>();
        transform.position = FollowObject.transform.position - Offset;
    }

    void Update()
    {
        if (playerCollision.GetOnGround() && FollowObject != null)
        {
            transform.position = FollowObject.transform.position - Offset;
        }
    }
}
