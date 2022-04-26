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
    public bool HasMoney{get {return PlayerStat.money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStat.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that turret");
            return; 
        }

        PlayerStat.money -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate (turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money left: " + PlayerStat.money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
