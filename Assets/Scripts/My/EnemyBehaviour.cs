using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Assets.Scripts.My;
using Unity.VisualScripting;

public class EnemyBehaviour : MonoBehaviour, IHp
{
    [SerializeField] int hpMax;
    [SerializeField] int radiusForWholeMap;
    [SerializeField] Weapon weapon;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float timeToUpdate;
    float timeToUpateCur = 0;

    Find find;

    int currentHp;
    NavMeshAgent agent;
    public List<EnemyBehaviour> currentListInWhichUnitIs = new List<EnemyBehaviour>();
    Status currentStatus;

    [Header("Find Enemy Stuff")]
    Collider[] colliders = new Collider[20];
    GameObject target;

    public int Hp
    {
        get { return currentHp; }
        set
        {
            currentHp = Mathf.Max(0, value);
            if (currentHp == 0) Death();
            Debug.Log("Damaged: " + currentHp);
        }
    }

    public GameObject Target
    {
        get
        {
            if (ReferenceEquals(target, null) || target.IsDestroyed())
            {
                target = find.FindClosestEnemy(radiusForWholeMap, transform, colliders, playerLayer);
            }

            return target;
        }
        set => target = value;
    }

    void Start()
    {
        timeToUpateCur = 0;
        find = new Find();

        currentHp = hpMax;
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        timeToUpateCur -= Time.deltaTime;
        if(timeToUpateCur <= 0)
        {
            WhatToDo();
            timeToUpateCur = timeToUpdate;
        }
        DoThing();
    }

    void WhatToDo()
    {
        if (StillInRange())
        {
            currentStatus = Status.attacking;
        }
        else if (Target != null)
        {
            currentStatus = Status.following;
        }
        else
        {
            currentStatus = Status.standing;
        }
    }

    void DoThing()
    {
        switch (currentStatus)
        {
            case Status.attacking:
                Attack();
                break;
            case Status.following:
                Follow();
                break;
            case Status.standing:
                Standing();
                break;
        }
    }

    void Attack()
    {
        if (!StillInRange())
        {
            weapon.fireRateCur = 0;
            Target = null;
        }
        else
        {
            gameObject.transform.LookAt(Target.transform.position);

            weapon.fireRateCur -= Time.deltaTime;
            if (weapon.fireRateCur <= 0)
            {
                weapon.ShootRay(transform.position, transform.forward, playerLayer);
                weapon.fireRateCur = weapon.fireRate;
            }
        }
    }

    void Follow()
    {
        if (Target != null)
        {
            agent.SetDestination(CalculatePosition(Target.transform.position, transform.position, weapon.range - (weapon.range / 10)));
        }
    }

    void Standing()
    {
        agent.SetDestination(transform.position);
    }

    bool StillInRange()
    {
        if (Target == null) return false;
        float distance = Vector3.Distance(transform.position, Target.transform.position);
        return distance <= weapon.range;
    }


    Vector3 CalculatePosition(Vector3 start, Vector3 end, int distance)
    {
        Vector3 direction = end - start;
        direction.Normalize();
        Vector3 scaledDirection = direction * distance;
        return start + scaledDirection;
    }

    void Death()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Manager.Instance.penize++;
        currentListInWhichUnitIs.Remove(this);
    }

}

class Find
{
    public GameObject FindClosestEnemy(float radius, Transform transform, Collider[] colliders, LayerMask playerLayer)
    {
        Debug.Log("Find");
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, radius, colliders, playerLayer);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < numColliders; i++)
        {
            float distance = Vector3.Distance(transform.position, colliders[i].transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = colliders[i].transform.root.gameObject;
            }
        }

        return closestEnemy;
    }
}

enum Status
{
    attacking,
    following,
    standing
}
