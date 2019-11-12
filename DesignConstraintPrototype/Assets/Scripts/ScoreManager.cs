using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.isDead) // only if the player is not dead
        {
            GameController.score += Mathf.Floor(Time.deltaTime * 100);
            // Debug.Log(GameController.score);
        }

    }
}
