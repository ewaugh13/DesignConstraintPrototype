using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBGM : MonoBehaviour
{
    public AudioClip MusicClip;

    public AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {
        BGM.clip = MusicClip;
        BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
