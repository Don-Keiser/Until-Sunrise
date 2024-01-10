using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class US_EnemyStats : MonoBehaviour
{
    public static US_EnemyStats instance;

    public int eDamage;

    [SerializeField] float eCurrentHealth;
    [SerializeField] float eMaxHealth;

    public bool eIsDead = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        eCurrentHealth = eMaxHealth;
    }

    public float eRemainingHealthPercentage
    {
        get
        {
            return eCurrentHealth / eMaxHealth;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (eCurrentHealth == 0)
        {
            eIsDead = true;
            return;
        }

        eCurrentHealth -= damageAmount;

        if (eCurrentHealth < 0)
        {
            eCurrentHealth = 0;
        }
    }
}
