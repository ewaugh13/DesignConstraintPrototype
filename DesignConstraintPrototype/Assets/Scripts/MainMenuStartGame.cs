using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuStartGame : MonoBehaviour
{
    #region Public Variables
    [Tooltip("The level to start")]
    [SerializeField]
    public string LevelName;

    [Tooltip("The text for loading info")]
    [SerializeField]
    public GameObject TextInput;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.anyKeyDown)
        {
            TextInput.GetComponent<Text>().text = "Loading...";
            SceneManager.LoadScene(LevelName);
        }
            
    }
}
