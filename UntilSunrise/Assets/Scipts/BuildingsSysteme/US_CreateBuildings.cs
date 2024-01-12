using UnityEngine;

public class US_CreateBuildings : MonoBehaviour
{
    [SerializeField] private GameObject ghostBuilding1;
    [SerializeField] private GameObject ghostBuilding2;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void BuildBuilding1()
    {
        if (gameManager.points >= 15)
        {
            Instantiate(ghostBuilding1);
            gameManager.points -= 15;
        }
    }
    public void BuildBuilding2()
    {
        if (gameManager.points >= 50)
        {
            Instantiate(ghostBuilding2);
            gameManager.points -= 50;
        }
    }

    private void Update()
    {
        if(gameManager.points < 0)
        {
            gameManager.points = 0;
        }
    }
}
