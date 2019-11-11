using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour
{

    #region Private variables
    private GameObject DeathUI;
    private float WaitForSec = 1.5f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        DeathUI = GameObject.Find("Reset UI Canvas");
        Debug.Log(DeathUI);
        DeathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // just a pseudo code of what needs to be done. Fell free to move this code where the game manages death condition
        if (GameController.isDead) // just a bool var in gameController that will be set for the death condition
        {
            // Display the UI
            DeathUI.SetActive(true);

            // Delay        IDK how to make delay in the subroutine.. SND HLP PLZ
            StartCoroutine("Delay");
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(WaitForSec);
        ResetScene();
    }

    private void ResetScene()
    {
        //DeathUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
