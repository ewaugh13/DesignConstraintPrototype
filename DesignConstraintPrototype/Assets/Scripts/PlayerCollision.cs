using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    #region Hidden Variables
    private Scene sceneToLoad;
    #endregion

    private void Start()
    {
        sceneToLoad = SceneManager.GetActiveScene();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Obsticale"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(sceneToLoad.name);
        }
    }
}
