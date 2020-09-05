using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distancetoEnemy < shortestDistance)
            {
                shortestDistance = distancetoEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy !=null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        //target lock on 
        Vector3 dir = target.position - transform.position;
        
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //convert quaternion to euler - x,y,z as shown in inspector
        //lerp will smoothly rotate head from partToRotate to lookRotation with speed of 10
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles;
        
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountDown >= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;

    }

    void Shoot()
    {
       GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet!=null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
