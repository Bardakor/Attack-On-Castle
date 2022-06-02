using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Material hoverMaterial;
    public Material redMaterial;
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

        if (turret != null)
        {
            BuildManager.instance.SelectNode(this);
            return;
        }

        if (!BuildManager.instance.CanBuild)
            return;

        //build turret
        BuildManager.instance.BuildTurretOn(this);
    }
    void OnMouseEnter ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!BuildManager.instance.CanBuild)
            return;

        if (BuildManager.instance.HasMoney)
        {
            rend.material = hoverMaterial; 
        }
        else
        {
            rend.material = redMaterial;
        }
        
    }
    void OnMouseExit ()
    {
        rend.material = startMaterial;
    }
}
