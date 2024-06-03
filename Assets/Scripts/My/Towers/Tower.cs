using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : BuildingMono
{
    Find find;

    [SerializeField] int radiusForWholeMap;
    Collider[] colliders = new Collider[20];
    GameObject target;

    [SerializeField] Weapon weapon;
    
    [SerializeField] Transform shootingOrigin;

    public GameObject Target
    {
        get
        {
            if (ReferenceEquals(target, null) || target.IsDestroyed())
            {
                target = find.FindClosestEnemy(radiusForWholeMap, transform, colliders, enemyLayer);
            }

            return target;
        }
        set => target = value;
    }

    override protected void Start()
    {
        base.Start();

        find = new Find();
    }

    private void Update()
    {
        if (ReferenceEquals(Target, null)) return;

        Shoot();
    }

    void Shoot()
    {
        gameObject.transform.LookAt(Target.transform.position);

        weapon.fireRateCur -= Time.deltaTime;
        if (weapon.fireRateCur <= 0)
        {
            weapon.ShootRay(shootingOrigin.position, Target.transform.position, enemyLayer);
            weapon.fireRateCur = weapon.fireRate;
        }

    }
}
