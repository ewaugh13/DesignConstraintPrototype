using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Public vars
    [Tooltip("Alove music")]
    [SerializeField]
    public GameObject AliveMusic;

    [Tooltip("Music on death")]
    [SerializeField]
    public GameObject DeadMusic;
    #endregion

    #region Private vars 
    private bool DeadMusicPlaying;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        AliveMusic.GetComponent<AudioSource>().Play();
        DeadMusic.GetComponent<AudioSource>().Stop();
        DeadMusicPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isDead && !DeadMusicPlaying)
        {
            AliveMusic.GetComponent<AudioSource>().Stop();
            DeadMusic.GetComponent<AudioSource>().Play();
            DeadMusicPlaying = true;
        }
    }
}
