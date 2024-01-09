using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class US_EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform enemySpawn;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);

            GameObject _enemy = US_EnemyPool.instance.GetPooledObject();

            if (_enemy != null ) 
            {
                _enemy.transform.position = enemySpawn.position;
                _enemy.SetActive(true);
            }
        }
    }
}
