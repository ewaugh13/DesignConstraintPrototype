using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour
{

    #region
    private GameObject DeathUI;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        DeathUI = GameObject.FindGameObjectWithTag("Death UI");
    }

    // Update is called once per frame
    void Update()
    {
        // just a pseudo code of what needs to be done. Fell free to move this code where the game manages death condition
        if (GameController.isDead) // just a bool var in gameController that will be set for the death condition
        {
            // Display the UI
            DeathUI.SetActive(true);

            // Restart Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // Delay        IDK how to make delay in the subroutine.. SND HLP PLZ
            StartCoroutine("Delay");

            // Disable UI
            DeathUI.SetActive(false);
        }
    }

    IEnumerator Delay()
    {
        yield return 0;
    }

    // If the player enters a trigger, the player resets
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            // Display score
            

            // Restart Scene
            
        }
    }
}
