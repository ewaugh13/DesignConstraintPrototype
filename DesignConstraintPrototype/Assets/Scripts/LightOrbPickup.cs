using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrbPickup : MonoBehaviour
{
    #region InstanceVariables
    [SerializeField]
    [Tooltip("The amount to raise light intensity (should be inbetween 0 and 1")]
    private float lightAmount = .33f;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.currentLightIntensity += lightAmount;
            if(GameManager.currentLightIntensity > 1.0f)
            {
                GameManager.currentLightIntensity = 1.0f;
            }

            Destroy(this.gameObject);
        }
    }
}
