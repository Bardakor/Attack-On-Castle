using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    //array of turret prefabs
    public GameObject[] turretPrefabs;

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
    private Node selectedNode;
    public NodeUI nodeUI; 
    public bool CanBuild{get {return turretToBuild != null; } }
    public bool HasMoney{get {return PlayerStat.money >= turretToBuild.cost; } }

    

    public void SelectNode (Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode ()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
