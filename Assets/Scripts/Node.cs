using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        { // when mouse is on shop panel, disable click on nodes to spawn turret
            return;
        }

        if (buildManager.GetTurrentToBuild() == null)
            return;

        if (turret != null)
            return;

        // build a turret
        GameObject turretToBuild = buildManager.GetTurrentToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurrentToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }
    
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }



}
