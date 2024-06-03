using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.My;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour, IHp
{
    [SerializeField] int hpMax;
    int currentHp;

    [SerializeField] Image healthBar;

    public static PlayerBehaviour mainPlayer;

    public int Hp
    {
        get { return currentHp; }
        set
        {
            currentHp = Mathf.Max(0, value);

            healthBar.fillAmount = (float)currentHp / (float)hpMax;

            if (currentHp == 0) Death();
        }
    }

    void Start()
    {
        mainPlayer = this;
        currentHp = hpMax;
    }

    void Update()
    {
        
    }

    void Death()
    {

    }
}
