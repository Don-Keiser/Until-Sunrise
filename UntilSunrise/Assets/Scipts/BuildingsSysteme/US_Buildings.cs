using UnityEngine;

public class US_Buildings : MonoBehaviour
{
    [SerializeField] private GameObject buildingsPrefab;
    [SerializeField] private LayerMask layer;

    RaycastHit hit;

    GameManager manager;
    private void Awake()
    {
        manager = FindAnyObjectByType<GameManager>();
    }

    private void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50.0f, layer))
        {
            transform.position = hit.point;
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50.0f, layer))
        {
            transform.position = hit.point;
        }

        if (Input.GetMouseButtonDown(0) && manager.CanBePlaced)
        {
            Instantiate(buildingsPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
            Destroy(gameObject);
        }

    }
}
