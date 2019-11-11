using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTouchingMyCheese : MonoBehaviour
{
    #region Instance Variables
    [SerializeField]
    [Tooltip("The GameObject to follow")]
    private GameObject FollowObject = null;
    [SerializeField]
    private Vector3 Offset = Vector3.zero;
    #endregion

    private void Start()
    {
        transform.position = FollowObject.transform.position - Offset;
    }

    void Update()
    {

            transform.position = FollowObject.transform.position - Offset;
        
    }
}
