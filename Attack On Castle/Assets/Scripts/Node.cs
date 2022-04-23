using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Material hoverMaterial;
    public Vector3 positionOffset;
    private GameObject turret;
    private Renderer rend;
    private Material startMaterial;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startMaterial = rend.material;
    }
    void OnMouseDown ()
    {
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
        rend.material = hoverMaterial; 
    }
    void OnMouseExit ()
    {
        rend.material = startMaterial;
    }
}
