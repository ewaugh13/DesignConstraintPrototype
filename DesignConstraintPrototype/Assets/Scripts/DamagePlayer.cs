using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour
{
    private string ObstacleArea = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // If the player enters a trigger, the player resets
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            // Display score


            // Restart Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
