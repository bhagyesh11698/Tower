﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuidPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        { // when mouse is on shop panel, disable click on nodes to spawn turret
            return;
        }

        if (!buildManager.canBuild)
            return;

        if (turret != null)
            return;

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
            return;

        rend.material.color = hoverColor;
    }
    
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }



}
