using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Material hoverMaterial;
    public Vector3 positionOffset;
    private GameObject turret;
    private Renderer rend;
    private Material startMaterial;

    //BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startMaterial = rend.material;

        //buildManager = BuildManager.instance;
    }
    void OnMouseDown ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.instance.GetTurretToBuild() == null)
            return;
            
        if (turret != null)
        {
            Debug.Log("Can't build there - TODO : Display on screen");
            return;
        }

        //build turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate (turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    void OnMouseEnter ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (BuildManager.instance.GetTurretToBuild() == null)
            return;

        rend.material = hoverMaterial; 
    }
    void OnMouseExit ()
    {
        rend.material = startMaterial;
    }
}
