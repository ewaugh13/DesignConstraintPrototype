using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    #region MemberVariables
    public float speed = 20.0f;
    #endregion

    #region Start
    void Start()
    {
        
    }
    #endregion

    #region Update
    void Update()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Walls");
        float zRotation = gameObject.transform.rotation.z;

        // Rotate Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.Rotate(0, 0, zRotation + 90);
        }

        // Rotate Right
        if(Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.Rotate(0, 0, zRotation - 90);
        }
    }
    #endregion
}
