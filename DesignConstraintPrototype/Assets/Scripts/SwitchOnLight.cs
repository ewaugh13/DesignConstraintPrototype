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
                this.gameObject.GetComponent<Light>().enabled = !this.gameObject.GetComponent<Light>().enabled;
            }
            else if (this.GetComponent<ParticleSystem>() != null)
            {
                Debug.Log("Particle Hit");
                var particle = this.GetComponent<ParticleSystem>();
                particle.Play();

            }
        }
    }
    #endregion
}
