using UnityEngine;

public class LowerLightIntensity : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Light>().intensity = GameManager.currentLightIntensity;
    }
}
