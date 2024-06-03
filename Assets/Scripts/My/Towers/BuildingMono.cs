using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMono : MonoBehaviour
{
    [SerializeField] protected LayerMask enemyLayer;

    [SerializeField] int hpMax;
    int hpCurrent;

    public int HP
    {
        get 
        {
            return hpCurrent;
        }
        set 
        {
            hpCurrent = Mathf.Max(0, value);
            if (hpCurrent == 0) Destruction();
        }
    }

    virtual protected void Start()
    {
        hpCurrent = hpMax;
    }

    protected void Destruction()
    {
        Destroy(gameObject);
    }

}
