using UnityEngine;
using System.Collections;

public class LightCull : MonoBehaviour
{

    [SerializeField]
    private GameObject lightToDisable;
    private GameObject Player;
    ///------------------------------
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
}