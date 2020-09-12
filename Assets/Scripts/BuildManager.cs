using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance!=null)
        {
            return;
        }
        instance = this;
    }
    
    private TurretBlueprint turrentToBuild;
    private Node seletedNode;

    public NodeUI nodeUI;

    public bool CanBuild     {   get { return turrentToBuild != null; }    }
    public bool HasMoney     {   get { return PlayerStats.Money >= turrentToBuild.cost; }    }
    // return false if enough money is not available


    public void OnDrawGizmosSelected(TurretBlueprint turret)
    {
        turrentToBuild = turret;
    }

    public void SelectNode(Node node)
    {
        if (seletedNode == node)
        {
            DeselectNode();
            return;
        }
        seletedNode = node;
        turrentToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        seletedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turrentToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turrentToBuild;
    }

}
