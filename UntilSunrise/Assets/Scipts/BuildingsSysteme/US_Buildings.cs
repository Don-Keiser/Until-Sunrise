using UnityEngine;

public class US_Buildings : MonoBehaviour
{
    [SerializeField] private GameObject buildingsPrefab;
    [SerializeField] private LayerMask layer;

    RaycastHit hit;
    public LayerMask test;

    private void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f, layer))
        {
            transform.position = hit.point;
        }
        test = hit.collider.gameObject.layer;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50.0f, layer))
        {
            transform.position = hit.point;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildingsPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
