using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{

    #region Instance variables
    [SerializeField]
    [Tooltip("The death UI")]
    private GameObject DeathUI = null;
    [Tooltip("Death UI text")]
    [SerializeField]
    private GameObject DeathUIText;
    [Tooltip("Player object")]
    [SerializeField]
    private GameObject player;
    #endregion

    #region Hidden Variables
    private float WaitForSec = 1.5f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        DeathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // just a pseudo code of what needs to be done. Fell free to move this code where the game manages death condition
        if (GameController.isDead && player != null) // just a bool var in gameController that will be set for the death condition
        {
            // Display the UI
            Destroy(player);
            DeathUIText.GetComponent<Text>().text = "The Darkness consumed you! \nYour score was " + GameController.score.ToString();
            DeathUI.SetActive(true);

            StartCoroutine(Delay());
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
