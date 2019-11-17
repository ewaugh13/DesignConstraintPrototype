using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    #region Instance Variables
    [Header("Tunnel Prefabs")]
    [SerializeField]
    private GameObject[] startTunnelPrefabs = null;
    [SerializeField]
    private GameObject[] earlyTunnelPrefabs = null;
    [SerializeField]
    private GameObject[] midTunnelPrefabs = null;
    [SerializeField]
    private GameObject[] lateTunnelPrefabs = null;
    [SerializeField]
    private GameObject[] finalTunnelPrefabs = null;

    // Location to Generate
    [Header("Player and Tunnel attributes")]
    [SerializeField]
    private Transform playerTransform = null;
    [SerializeField]
    private float tunnelLength = 60.0f;
    [SerializeField]
    private int numStartTunnels = 5;
    [SerializeField]
    private int numEarlyTunnels = 10;
    [SerializeField]
    private int numMidTunnels = 20;
    [SerializeField]
    private int numLateTunnels = 40;
    #endregion

    #region HiddenVariables
    private float tunnelSpawnLocationZ = 0.0f;
    // Keep Track of Active Tunnels
    private List<GameObject> activeTunnels = null;
    private int lastTunnelIndex = 0;
    private int numberOfTunnelsGenerated = 0;
    private int numActiveTunnelsAllowed = 12;
    #endregion

    void Start()
    {
        // Holds the tunnel objects on the screen
        activeTunnels = new List<GameObject>();
        for (int i = 0; i < numStartTunnels; i++)
        {
            SpawnTunnel(startTunnelPrefabs);
        }
        TurnOnStartLights();
    }


    void Update()
    {
        // Spawning Tunnels
        if (playerTransform != null)
        {
            if (playerTransform.position.z > (tunnelSpawnLocationZ - (tunnelLength * 10)))
            {
                if (numberOfTunnelsGenerated - numStartTunnels < numEarlyTunnels)
                {
                    SpawnTunnel(earlyTunnelPrefabs);
                }
                else if (numberOfTunnelsGenerated - numStartTunnels - numEarlyTunnels < numMidTunnels)
                {
                    SpawnTunnel(midTunnelPrefabs);
                }
                else if (numberOfTunnelsGenerated - numStartTunnels - numEarlyTunnels - numMidTunnels < numLateTunnels)
                {
                    SpawnTunnel(lateTunnelPrefabs);
                }
                else
                {
                    SpawnTunnel(finalTunnelPrefabs);
                }
            }

            // Deleting Tunnels
            if (activeTunnels.Count > numActiveTunnelsAllowed)
            {
                DeleteTunnel();
            }
        }
    }

    private void TurnOnStartLights()
    {
        for (int i = 0; i < activeTunnels.Count; i++)
        {
            activeTunnels[i].GetComponentInChildren<Light>().enabled = true;
        }
    }

    private void SpawnTunnel(GameObject[] tunnelPrefabs)
    {
        GameObject tunnel;
        tunnel = Instantiate(tunnelPrefabs[RandomTunnelIndex(tunnelPrefabs)]) as GameObject;
        tunnel.transform.position = Vector3.forward * tunnelSpawnLocationZ;
        tunnelSpawnLocationZ += tunnelLength;
        numberOfTunnelsGenerated++;
        activeTunnels.Add(tunnel);
        tunnel.transform.SetParent(this.transform);
        tunnel.transform.rotation = tunnel.transform.parent.GetChild(0).transform.rotation;
    }

    private void DeleteTunnel()
    {
        Destroy(activeTunnels[0]);
        activeTunnels.RemoveAt(0);
    }

    // Random Index Generator
    private int RandomTunnelIndex(GameObject[] tunnelPrefabs)
    {
        if(tunnelPrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastTunnelIndex;
        while(randomIndex == lastTunnelIndex)
        {
            randomIndex = Random.Range(0, tunnelPrefabs.Length);
        }
        lastTunnelIndex = randomIndex;
        return randomIndex;
    }
}
