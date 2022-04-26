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

    private TurretBlueprint turretToBuild;
    public bool CanBuild{get {return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        GameObject turret = (GameObject) Instantiate (turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
