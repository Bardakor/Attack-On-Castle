 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;

    public float minx;
    public float maxx;
    public float miny;
    public float maxy; 

    private void Start()
    {
        Vector3 randomPos = new Vector3(Random.Range(minx, maxx), Random.Range(miny, maxy), 0);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
    }
}
