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
    #endregion

    private void Start()
    {
        sceneToLoad = SceneManager.GetActiveScene();
        GameController.isDead = false;
        GameController.onGround = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Obsticale"))
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

        CheckForPitDeath();
    }

    public void CheckForPitDeath()
    {
        if (!CheckOnGround())
        {
            StartCoroutine(WaitKillPlusRespawn(respawnTime));
        }
    }

    public bool CheckOnGround()
    {
        if (this.gameObject != null)
        {
            Physics.Raycast(this.gameObject.transform.position, Vector3.down, 1.0f);
            GameController.onGround = Physics.Raycast(this.gameObject.transform.position, Vector3.down, out RaycastHit hitInfo, 1.0f);
            if (hitInfo.collider != null && hitInfo.collider.gameObject.tag.Equals("Pit"))
            {
                GameController.onGround = false;
            }
            return GameController.onGround;
        }
        else
        {
            GameController.onGround = false;
        }
        return GameController.onGround;
    }

    private void KillAndRespawnPlayer()
    {
        GameController.isDead = true;
    }

    private IEnumerator WaitKillPlusRespawn(float time)
    {
        yield return new WaitForSeconds(time);
        if (!CheckOnGround())
        {
            KillAndRespawnPlayer();
        }
    }
}
