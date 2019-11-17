using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region GameController Variables
    static public bool isDead = false;
    static public bool onGround = true;
    static public int score = 0;
    static public float deaths = 0;
    static public float currentLightIntensity = 1.0f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        currentLightIntensity = 1.0f;
        score = 0;
        deaths = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
