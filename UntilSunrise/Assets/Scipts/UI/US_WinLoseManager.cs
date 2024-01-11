using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class US_WinLoseManager : MonoBehaviour
{
    public static US_WinLoseManager instance;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    public bool hasWon = false;
    public bool hasLost = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        CheckWinLoseCondition();
    }

    private void CheckWinLoseCondition()
    {
        if (hasWon || hasLost)
        {
            Time.timeScale = 0f;
        }

        if (hasWon)
        {
            winPanel.SetActive(true);
        }

        if (hasLost)
        {
            losePanel.SetActive(true);
        }
    }
}
