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
        GameController.score += 1;
        Debug.Log(GameController.score);
    }
}
