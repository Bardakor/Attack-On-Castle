
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseCannonItem()
    {
        Debug.Log("Cannon Item Purchased");
        buildManager.SetTurretToBuild(buildManager.cannonTurretPrefab);
    }
    public void PurchaseBaliseItem()
    {
        Debug.Log("Baliste Item Purchased");
        buildManager.SetTurretToBuild(buildManager.balistaTurretPrefab);
    }
    public void PurchaseCatapultItem()
    {
        Debug.Log("Catapult Item Purchased");
        buildManager.SetTurretToBuild(buildManager.catapultTurretPrefab);
    }
}
