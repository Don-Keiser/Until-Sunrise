using UnityEngine;

public class US_ColliderGroundBuildingsDetector : MonoBehaviour
{
    GameManager manager;

    private void Awake()
    {
        manager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        //turn of placement with collition detection

    }
}
