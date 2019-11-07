using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region Instance Variables
    [SerializeField]
    [Tooltip("The GameObject to follow")]
    private GameObject FollowObject = null;
    #endregion

    void Update()
    {
        transform.position = FollowObject.transform.position;
    }
}
