using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class US_EnemyStats : MonoBehaviour
{
    private GameManager gameManager;

    public static US_EnemyStats instance;

    public int eDamage;

    public float eCurrentHealth;
    public float eMaxHealth;

    public bool eIsDead = false;

    public bool scoreAdded = false;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();

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

            if (!scoreAdded)
            {
                gameManager.points += 2;
                scoreAdded = true;
            }

            gameObject.SetActive(false);
            return;
        }

        eCurrentHealth -= damageAmount;

        if (eCurrentHealth < 0)
        {
            eCurrentHealth = 0;
        }
    }
}
