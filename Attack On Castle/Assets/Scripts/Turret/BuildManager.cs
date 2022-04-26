using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake () //method to avoid to many build managers, be careful with multyplayer
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this; 
    }

    public GameObject balistaTurretPrefab;
    public GameObject cannonTurretPrefab;
    public GameObject catapultTurretPrefab;

    void Start()
    {
        turretToBuild = null;
    }
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
}
