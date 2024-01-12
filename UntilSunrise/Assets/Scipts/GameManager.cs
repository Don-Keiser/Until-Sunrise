using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LayerMask mask;

    Camera cam;
    RaycastHit hit;
    GameObject go;

    public bool CanBePlaced = false;
    public bool ShouldBePlaced = false;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f, mask))
        {
            go = hit.collider.gameObject;

            if (go.layer == 6)
            {
                CanBePlaced = true;
            }
            else
                CanBePlaced = false;
        }
    }
}
