using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region GameController Variables
    static public bool isDead = false;
    static public bool onGround = true;
    static public float score = 0;
    static public float deaths = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        deaths = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
