using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessAdjuster : MonoBehaviour
{
    #region InstanceVariables
    [SerializeField]
    [Tooltip("Material to change for light intensity")]
    private Material materialToDarken = null;
    [SerializeField]
    [Tooltip("Start emissiveIntensity for the material")]
    private float startEmissiveIntensity = 5.75f;
    #region InstanceVariables
    [SerializeField]
    [Tooltip("Amount to decrease the light (somewhere inbetween 0 and 1)")]
    private float lightDecreaseAmount = 0.01f;
    #endregion
    #endregion

    #region HiddenVariables
    private float currentEmissiveIntensity;
    #endregion

    #region ConstVariables
    //readonly string colorName = "Color_EB0D9F9F";
    readonly string emissiveIntensityName = "_EmissiveIntensity";
    readonly string colorIntensityName = "_ColorIntensity";
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        materialToDarken.SetFloat(emissiveIntensityName, startEmissiveIntensity);
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.currentLightIntensity -= (lightDecreaseAmount * Time.deltaTime);
        if(GameManager.currentLightIntensity < 0.0f)
        {
            GameManager.currentLightIntensity = 0.0f;
        }
        currentEmissiveIntensity = (GameManager.currentLightIntensity * startEmissiveIntensity);
        materialToDarken.SetFloat(emissiveIntensityName, currentEmissiveIntensity);
        materialToDarken.SetFloat(colorIntensityName, GameManager.currentLightIntensity);
    }

    void OnApplicationQuit()
    {
        materialToDarken.SetFloat(emissiveIntensityName, startEmissiveIntensity);
        materialToDarken.SetFloat(emissiveIntensityName, 1.0f);
    }
}
