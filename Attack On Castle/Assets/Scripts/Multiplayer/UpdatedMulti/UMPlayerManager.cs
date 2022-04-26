using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UMPlayerManager : MonoBehaviour
{
    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void CreateController()
    {
        Debug.Log("Instantiate Player");
    }

    void Start()
    {
        if(PV.IsMine)
        {
            CreateController();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
