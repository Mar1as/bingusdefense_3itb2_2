using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HealthandAmmo : BuildingMono
{
    [SerializeField] float delayMax;
    float delayCur;

    [SerializeField] GameObject player; //HP
    [SerializeField] List<GunScript> playerGuns; //AMMO
    [SerializeField] float addAmoutAmmo, addAmountHP;

    private void Start()
    {
        base.Start();

        delayCur = delayMax;
    }

    private void Update()
    {
        delayCur -= Time.deltaTime;
        if (delayCur <= 0)
        {
            delayCur = delayMax;
            
            PlayerBehaviour.mainPlayer.Hp += Mathf.CeilToInt(addAmountHP);
            foreach (var gun in playerGuns)
            {
                gun.bulletsIHave += Mathf.CeilToInt(addAmoutAmmo * gun.amountOfBulletsPerLoad);
            }
        }
    }
}
