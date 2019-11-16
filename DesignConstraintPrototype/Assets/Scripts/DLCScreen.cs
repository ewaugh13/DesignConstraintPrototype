using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DLCScreen : MonoBehaviour
{
    #region MemberVariable
    [Tooltip("Scene to open on touch")]
    [SerializeField]
    private string sceneToOpen = "";
    [Tooltip("DLC image")]
    [SerializeField]
    private GameObject dlcImage = null;
    [Tooltip("Loading image")]
    [SerializeField]
    private GameObject LoadiingImage = null;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        LoadiingImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.anyKeyDown)
        {
            dlcImage.SetActive(false);
            LoadiingImage.SetActive(true);
            SceneManager.LoadScene(sceneToOpen);
        }
    }
}

