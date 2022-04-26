using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Material hoverMaterial;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    private Renderer rend;
    private Material startMaterial;

    //BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startMaterial = rend.material;

        //buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.instance.CanBuild)
            return;
            
        if (turret != null)
        {
            Debug.Log("Can't build there - TODO : Display on screen");
            return;
        }

        //build turret
        BuildManager.instance.BuildTurretOn(this);
    }
    void OnMouseEnter ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.instance.CanBuild)
            return;

        rend.material = hoverMaterial; 
    }
    void OnMouseExit ()
    {
        rend.material = startMaterial;
    }
}
