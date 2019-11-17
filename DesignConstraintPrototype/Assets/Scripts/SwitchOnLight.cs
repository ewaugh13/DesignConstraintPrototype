using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnLight : MonoBehaviour
{
    #region MemberVariables
    //public GameObject hallwayLight;
    //public GameObject collisionObject;
    #endregion

    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("LightCuller"))
        {
            if (this.gameObject.GetComponent<Light>() != null)
            {
                if (other.gameObject.name.Contains("Forward"))
                {
                    this.gameObject.GetComponent<Light>().enabled = true;
                }
                else
                {
                    this.gameObject.GetComponent<Light>().enabled = false;
                }
            }
            else if (this.GetComponent<ParticleSystem>() != null)
            {
                var particle = this.GetComponent<ParticleSystem>();
                particle.Play();
            }
        }
    }
    #endregion

    private void Update()
    {
        this.gameObject.GetComponent<Light>().intensity = GameManager.currentLightIntensity;
    }
}
