using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    #region MemberVariables
    public GameObject[] wallPrefabs;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float wallLength = 2.0f;
    private int wallsOnScreen = 10;
    private List<GameObject> activeWalls;
    private float safeZone = 4;

    private int lastWallIndex = 0;
    #endregion

    #region Start
    void Start()
    {
        activeWalls = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < wallsOnScreen; i++)
        {
            if (i < 4)
            {
                SpawnWall(0);
            }
            else
            {
                SpawnWall();
            }
        }
    }
    #endregion

    #region Update
    void Update()
    {
        if((playerTransform.position.z - safeZone) > (spawnZ - (wallsOnScreen * wallLength)))
        {
            SpawnWall();
            DeleteWall();
        }
    }
    #endregion

    #region SpawnWall
    private void SpawnWall(int prefabIndex = -1)
    {
        GameObject wall;
        if (prefabIndex == -1)
        {
            wall = Instantiate(wallPrefabs[RandomWallIndex()]) as GameObject;
        }
        else
        {
            wall = Instantiate(wallPrefabs[prefabIndex]);
        }
        wall.transform.SetParent(this.transform);
        wall.transform.position = Vector3.forward * spawnZ;
        spawnZ += wallLength;
        activeWalls.Add(wall);
    }
    #endregion

    #region DeleteWall
    private void DeleteWall()
    {
        Destroy(activeWalls[0]);
        activeWalls.RemoveAt(0);
    }
    #endregion

    #region RandomWallIndex
    private int RandomWallIndex()
    {
        if(wallPrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastWallIndex;
        while(randomIndex == lastWallIndex)
        {
            randomIndex = Random.Range(0, wallPrefabs.Length);
        }

        lastWallIndex = randomIndex;
        return randomIndex;
    }
    #endregion
}
