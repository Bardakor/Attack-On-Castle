
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint cannonTurret;
    public TurretBlueprint balistaTurret;
    public TurretBlueprint catapultTurret;
    BuildManager buildManager;
    

    void Start ()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectCannonItem()
    {
        Debug.Log("Cannon Item Purchased");
        buildManager.SelectTurretToBuild(cannonTurret);
    }
    public void SelectBaliseItem()
    {
        Debug.Log("Baliste Item Purchased");
        buildManager.SelectTurretToBuild(balistaTurret);
    }
    public void SelectCatapultItem()
    {
        Debug.Log("Catapult Item Purchased");
        buildManager.SelectTurretToBuild(catapultTurret);
    }
}
