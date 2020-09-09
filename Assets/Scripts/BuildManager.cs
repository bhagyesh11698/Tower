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

    public bool CanBuild     {   get { return turrentToBuild != null; }    }
    public bool HasMoney     {   get { return PlayerStats.Money >= turrentToBuild.cost; }    }
    // return false if enough money is not available


    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turrentToBuild.cost)
        {

            return;
        }

        PlayerStats.Money -= turrentToBuild.cost;


        // build a turret
       GameObject turret = (GameObject)Instantiate(turrentToBuild.prefab, node.GetBuidPosition(), Quaternion.identity);
       node.turret = turret;

        Debug.Log("Turret Built Money Left : " + PlayerStats.Money);
    }

    public void OnDrawGizmosSelected(TurretBlueprint turret)
    {
        turrentToBuild = turret;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turrentToBuild = turret;
    }

}
