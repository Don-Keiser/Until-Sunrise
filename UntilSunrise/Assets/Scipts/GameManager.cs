using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    Camera cam;
    RaycastHit hit;
    GameObject go;

    public bool CanBePlaced = false;
    public bool ShouldBePlaced = false;

    [Header("Score")]
    public int points = 0;

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

        textMeshPro.text = points.ToString();
    }
}
