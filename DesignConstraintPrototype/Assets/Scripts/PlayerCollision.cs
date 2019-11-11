using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    #region Instance Variables
    [SerializeField]
    [Tooltip("Time to wait till droping ball is destroyed and scene restarts")]
    private float respawnTime = 1.0f;
    #endregion

    #region Hidden Variables
    private Scene sceneToLoad;
    private GameObject ResetUICanvas;
    private Component UICanvas;
    private bool onGround;
    #endregion

    #region Getters and Setters
    public bool GetOnGround() { return this.onGround; }
    #endregion

    private void Start()
    {
        sceneToLoad = SceneManager.GetActiveScene();
        ResetUICanvas = GameObject.Find("Reset UI Canvas");
        GameController.isDead = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Obsticale"))
        {
            KillAndRespawnPlayer();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Obsticale"))
        {
            KillAndRespawnPlayer();
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Obsticale"))
        {
            KillAndRespawnPlayer();
        }

        onGround = CheckOnGround();
        if(!onGround)
        {
            StartCoroutine(WaitKillPlusRespawn(respawnTime));
        }
    }

    public bool CheckOnGround()
    {
        return Physics.Raycast(this.gameObject.transform.position, Vector3.down, 1.0f);
    }

    private void KillAndRespawnPlayer()
    {
        GameController.isDead = true;
        //Destroy(this.gameObject);
        //SceneManager.LoadScene(sceneToLoad.name);
    }

    private IEnumerator WaitKillPlusRespawn(float time)
    {
        yield return new WaitForSeconds(time);

        KillAndRespawnPlayer();
    }
}
