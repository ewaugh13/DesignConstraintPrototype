using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnLight : MonoBehaviour
{
    #region MemberVariables
    //public GameObject hallwayLight;
    //public GameObject collisionObject;
    #endregion

    #region OnCollisionEnter
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("HallwayLight"))
        {
            collision.gameObject.GetComponent<Light>().enabled = true;
        }
    }
    #endregion

    #region OnCollisionExit
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("HallwayLight"))
        {
            collision.gameObject.GetComponent<Light>().enabled = false;
        }
    }
    #endregion
}
