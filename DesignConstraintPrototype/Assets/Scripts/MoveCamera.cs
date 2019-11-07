using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    #region MemberVariables
    private Transform target;
    private Vector3 startOffset;
    private Vector3 moveVector;

    //private float transition = 0.0f;
    //private float animationDuration = 2.0f;
    //private Vector3 animationOffset = new Vector3(0, 0, -3);
    #endregion

    #region Start
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = this.transform.position - target.position;
    }
    #endregion

    #region Update
    void Update()
    {
        moveVector = target.position + startOffset;

        moveVector.x = 0; // Always centered on the track
        moveVector.y = 0.3f; // Always centered above the track
        //moveVector.y = Mathf.Clamp(moveVector.y, 3, 5); // If there are ups and downs

        this.transform.position = moveVector;

        //// Required for Initial Animation
        //if (transition > 1.0f)
        //{
        //    this.transform.position = moveVector;
        //}
        //else
        //{
        //    this.transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
        //    transition += Time.deltaTime * 1 / animationDuration; // The total time of the starting animation
        //    this.transform.LookAt(target.position + Vector3.up);
        //}
    }
    #endregion
}
