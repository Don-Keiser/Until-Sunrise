using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class US_BaseStats : MonoBehaviour
{
    public static US_BaseStats instance;

    [SerializeField] float bCurrentHealth;
    [SerializeField] float bMaxHealth;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        bCurrentHealth = bMaxHealth;
    }

    public float bRemainingHealthPercentage
    {
        get
        {
            return bCurrentHealth / bMaxHealth;
        }
    }

    public UnityEvent OnHealthChange;

    public void TakeDamage(float damageAmount)
    {
        if (bCurrentHealth == 0)
        {
            US_WinLoseManager.instance.hasLost = true;
            return;
        }

        bCurrentHealth -= damageAmount;

        OnHealthChange.Invoke();

        if (bCurrentHealth < 0)
        {
            bCurrentHealth = 0;
        }
    }
}
