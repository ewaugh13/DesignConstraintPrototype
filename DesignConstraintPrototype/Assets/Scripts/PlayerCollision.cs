using System.Collections;
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
        GameManager.isDead = false;
        GameManager.onGround = true;
    }

    private void OnCollisionEnter(Collision collision)
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
        if (this != null && this.gameObject != null)
        {
            Physics.Raycast(this.gameObject.transform.position, Vector3.down, 1.0f);
            GameManager.onGround = Physics.Raycast(this.gameObject.transform.position, Vector3.down, out RaycastHit hitInfo, 1.0f);
            if (hitInfo.collider != null && hitInfo.collider.gameObject.tag.Equals("Pit"))
            {
                GameManager.onGround = false;
            }
            return GameManager.onGround;
        }
        else
        {
            GameManager.onGround = false;
        }
        return GameManager.onGround;
    }

    private void KillAndRespawnPlayer()
    {
        GameManager.isDead = true;
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
