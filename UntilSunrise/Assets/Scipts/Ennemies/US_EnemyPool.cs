using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class US_EnemyPool : MonoBehaviour
{
    public static US_EnemyPool instance;

    public List<GameObject> pooledEnemies = new List<GameObject>();
    [SerializeField] int amountToPool;
    [SerializeField] GameObject enemyPrefab;


    public Transform[] waypoints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            pooledEnemies.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledEnemies.Count; i++)
        {
            if (!pooledEnemies[i].gameObject.activeInHierarchy)
            {
                return pooledEnemies[i];
            }
        }
        return null;
    }
}
