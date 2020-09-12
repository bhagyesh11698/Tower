using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


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

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }


        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {

            return;
        }

        PlayerStats.Money -= blueprint.cost;


        // build a turret
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuidPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;

        Debug.Log("Turret Built");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {

            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        // destroy old turret
        Destroy(turret);

        // build a new upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuidPosition(), Quaternion.identity);
        turret = _turret;
        isUpgraded = true;


        Debug.Log("Turret Built");
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        rend.material.color = notEnoughMoneyColor;
    }
    
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
