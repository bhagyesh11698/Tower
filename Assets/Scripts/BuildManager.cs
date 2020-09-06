using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        instance = this;
    }
    
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    /*private void Start()
    {
        turrentToBuild = standardTurretPrefab;
    }*/
    private GameObject turrentToBuild;

    public GameObject GetTurrentToBuild()
    {
        // get turret from other script to build
        return turrentToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turrentToBuild = turret;
    }    
}
