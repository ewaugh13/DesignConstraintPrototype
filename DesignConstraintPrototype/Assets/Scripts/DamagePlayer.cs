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
    private GameObject DeathUIText = null;
    [Tooltip("Player object")]
    [SerializeField]
    private GameObject player = null;
    [Tooltip("Death message")]
    [SerializeField]
    private string DeathMsg = "";
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
        if (GameManager.isDead && player != null) // just a bool var in gameController that will be set for the death condition
        {
            Destroy(player); // destroy the ball so the camera does not move forward
            GameManager.deaths += 1; // increase death counter for the DLC screen

            DeathUIText.GetComponent<Text>().text = DeathMsg + GameManager.score.ToString();
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
        GameManager.currentLightIntensity = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
