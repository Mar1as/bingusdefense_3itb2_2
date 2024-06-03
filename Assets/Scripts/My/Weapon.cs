using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.My;


[Serializable]
public class Weapon
{
    public int range;
    public int damage;
    public float fireRate;
    public float fireRateCur = 0;
    public GameObject graphicBulletPrefab;

    public Weapon()
    {
        fireRateCur = fireRate;
    }

    public void ShootRay(Vector3 origin, Vector3 direction, LayerMask targetLayer)
    {
        RaycastHit hit;
        if (Physics.Raycast(origin, direction, out hit, range, targetLayer))
        {
            IHp enemy = hit.collider.GetComponent<IHp>();
            if (enemy != null)
            {
                enemy.Hp -= damage;
            }
        }

        ShootGraphics(origin, direction);
    }

    void ShootGraphics(Vector3 position, Vector3 direction)
    {
        if (graphicBulletPrefab != null)
        {
            GameObject bullet = GameObject.Instantiate(graphicBulletPrefab, position, Quaternion.LookRotation(direction));
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * 20f; 
            }
            GameObject.Destroy(bullet, 10);
        }
    }
}
