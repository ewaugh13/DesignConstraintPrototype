using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GameManager.isDead) // only if the player is not dead
        {
            GameManager.score += (int)(Time.deltaTime * 100);
        }
    }
}
