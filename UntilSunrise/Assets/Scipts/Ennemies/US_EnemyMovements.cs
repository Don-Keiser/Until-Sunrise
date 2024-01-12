using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class US_EnemyMovements : MonoBehaviour
{
    private int currentWaypointIndex = 0;

    [SerializeField] float speed;

    [SerializeField] US_EnemyPool ePool;

    US_EnemyStats stats;

    private void Awake()
    {
        ePool = FindAnyObjectByType<US_EnemyPool>();
        stats = GetComponent<US_EnemyStats>();
    }

    private void OnEnable()
    {
        currentWaypointIndex = 0;
        stats.eCurrentHealth = stats.eMaxHealth;
        stats.eIsDead = false;
        stats.scoreAdded = false;
        StartCoroutine(EnemyMovement());

    }

    private void OnDisable()
    {
        StopCoroutine(EnemyMovement());
    }

    private IEnumerator EnemyMovement()
    {
        Debug.Log("Coroutine Started");
        while (true)
        {
            Transform _waypoint = ePool.waypoints[currentWaypointIndex];

            if (Vector3.Distance(transform.position, _waypoint.position) <= 0.01f)
            {
                transform.position = _waypoint.position;

                currentWaypointIndex = (currentWaypointIndex + 1) % ePool.waypoints.Length;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _waypoint.position, speed * Time.deltaTime);
                transform.LookAt(_waypoint.position);
            }
            yield return null;
        }
    }
}
