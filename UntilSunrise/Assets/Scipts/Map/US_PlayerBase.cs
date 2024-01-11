using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class US_PlayerBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemies"))
        {
            other.gameObject.SetActive(false);
            US_BaseStats.instance.TakeDamage(US_EnemyStats.instance.eDamage);
        }
    }
}
