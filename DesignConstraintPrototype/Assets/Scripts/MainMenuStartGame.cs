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

    [Tooltip("'Start' Image")]
    [SerializeField]
    public GameObject StartImage;

    [Tooltip("'Loading' Image")]
    [SerializeField]
    public GameObject LoadingImage;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StartImage.SetActive(true);
        LoadingImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.anyKeyDown)
        {
            StartImage.SetActive(false);
            LoadingImage.SetActive(true);
            SceneManager.LoadScene(LevelName);
        }    
    }
}
