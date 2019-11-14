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
    public GameObject DeathUI = null;
    [Tooltip("Death UI text")]
    [SerializeField]
    public GameObject DeathUIText;
    [Tooltip("Player object")]
    [SerializeField]
    public GameObject player;
    [Tooltip("Death message")]
    [SerializeField]
    public string DeathMsg;
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
            Destroy(player); // destroy the ball so the camera does not move forward
            GameController.deaths += 1; // increase death counter for the DLC screen
            if (GameController.deaths % 5 == 0) // Every 5 deaths, display DLC if not, display death screen
            {

            }
            DeathUIText.GetComponent<Text>().text = DeathMsg + GameController.score.ToString();
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
