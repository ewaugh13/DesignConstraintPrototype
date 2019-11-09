using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrbCollision : MonoBehaviour
{
    #region MemberVariables
    [SerializeField]
    private float reduceIntenstitySpeed = 0;
    private Light playerLight;
    private float playerStartLightIntensity;
    #endregion

    #region Start
    void Start()
    {
        playerLight = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Light>();
        playerStartLightIntensity = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Light>().intensity;
    }
    #endregion

    #region Update
    void Update()
    {
        if (playerLight.intensity > 0)
        {
            playerLight.intensity -= reduceIntenstitySpeed * Time.deltaTime;
        }
    }
    #endregion

    #region OnCollisionEnter
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("LightOrb"))
        {
            playerLight.intensity = playerStartLightIntensity;
            Destroy(collision.gameObject);
        }
    }
    #endregion
}
