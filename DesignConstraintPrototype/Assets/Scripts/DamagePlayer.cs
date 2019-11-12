using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{

    #region Private variables
    private float WaitForSec = 1.5f;
    #endregion

    #region Publiuc variables
    [Tooltip("The death UI canvas")]
    [SerializeField]
    public GameObject DeathUI;
    [Tooltip("Death UI text")]
    [SerializeField]
    public GameObject DeathUIText;
    [Tooltip("Player object")]
    [SerializeField]
    public GameObject player;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DeathUI);
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
            DeathUIText.GetComponent<Text>().text = GameController.score.ToString();
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
