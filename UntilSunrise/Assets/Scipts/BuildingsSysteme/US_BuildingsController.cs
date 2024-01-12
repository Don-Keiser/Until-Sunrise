using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class US_BuildingsController : MonoBehaviour
{
    public static US_BuildingsController Instance;

    [Header("Combat Settings")]
    [SerializeField] private GameState buildingType;
    [SerializeField] private LayerMask ennemiesLayer;
    [SerializeField] private int stoneDamage;
    [SerializeField] private float stoneRange;
    [SerializeField] private float stoneShootingSpeed;
    [SerializeField] private int arrowDamage;
    [SerializeField] private float arrowRange;
    [SerializeField] private float arrowShootingSpeed;

    private bool hasShoot = false;

    public GameObject currentEnnemy;

    private float distance;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (buildingType == GameState.StoneThrower)
        {
            DetectionRange(stoneRange);
        }
        else if (buildingType == GameState.ArrowThrower)
        {
            DetectionRange(arrowRange);
        }

        if (currentEnnemy != null)
        {
            //look at
            gameObject.transform.LookAt(currentEnnemy.transform.position);
        }
    }

    private void DetectionRange(float _range)
    {
        Collider[] collision = Physics.OverlapSphere(transform.position, _range, ennemiesLayer);

        foreach (Collider _coll in collision)
        {
            distance = Vector3.Distance(transform.position, _coll.ClosestPoint(transform.position));
            currentEnnemy = _coll.gameObject;

            //Stone Shoot
            if (buildingType == GameState.StoneThrower)
            {
                US_EnemyStats eStats = currentEnnemy.GetComponent<US_EnemyStats>();

                if (!hasShoot && currentEnnemy != null)
                {
                    StartCoroutine(StoneShoot(eStats, stoneDamage));
                   
                    if (eStats.eIsDead)
                    {
                        currentEnnemy = null;
                    }
                }

                if (currentEnnemy == null)
                {
                    StopCoroutine(StoneShoot(eStats, stoneDamage));
                    hasShoot = false;
                }

            }
            //Arrow Shoot
            else if (buildingType == GameState.ArrowThrower)
            {
                US_EnemyStats eStats = currentEnnemy.GetComponent<US_EnemyStats>();

                if (!hasShoot && currentEnnemy != null)
                {
                    StartCoroutine(ArrowShoot(eStats, arrowDamage + 1));

                    if (eStats.eIsDead)
                    {
                        currentEnnemy = null;
                    }
                }

                if (currentEnnemy == null)
                {
                    StopCoroutine(ArrowShoot(eStats, arrowDamage + 1));
                    hasShoot = false;
                }
            }
        }

        if (distance > _range)
        {
            currentEnnemy = null;
        }
    }

    private IEnumerator StoneShoot(US_EnemyStats _eStats, int _damage)
    {
        hasShoot = true;
        _eStats.TakeDamage(_damage);
        yield return new WaitForSeconds(stoneShootingSpeed);
        hasShoot = false;
    }
    private IEnumerator ArrowShoot(US_EnemyStats _eStats, int _damage)
    {
        hasShoot = true;
        _eStats.TakeDamage(_damage);
        yield return new WaitForSeconds(arrowShootingSpeed);
        hasShoot = false;
    }

    public enum GameState
    {
        StoneThrower = 0,
        ArrowThrower = 1
    }

}
