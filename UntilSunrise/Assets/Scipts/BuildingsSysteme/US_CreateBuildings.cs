using UnityEngine;

public class US_CreateBuildings : MonoBehaviour
{
    [SerializeField] private GameObject ghostBuilding1;
    [SerializeField] private GameObject ghostBuilding2;

    public void BuildBuilding1()
    {
        Instantiate(ghostBuilding1);
    }    
    public void BuildBuilding2()
    {
        Instantiate(ghostBuilding2);
    }
}
