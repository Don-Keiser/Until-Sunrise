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
            //MakeDamage(stoneDamage);
        }
        else if (buildingType == GameState.ArrowThrower)
        {
            DetectionRange(arrowRange);
            //MakeDamage(arrowDamage);
        }

        if (currentEnnemy != null)
        {
            //look at
            this.gameObject.transform.LookAt(currentEnnemy.transform.position);
        }
    }

    private void DetectionRange(float _range)
    {
        Collider[] collision = Physics.OverlapSphere(transform.position, _range, ennemiesLayer);

        foreach (Collider _coll in collision) 
        {
            distance = Vector3.Distance(transform.position, _coll.ClosestPoint(transform.position));
            currentEnnemy = _coll.gameObject;
        }

        if (distance > _range)
        {
            currentEnnemy = null;
        }
    }

    public enum GameState
    {
        StoneThrower = 0,
        ArrowThrower = 1
    }

}
