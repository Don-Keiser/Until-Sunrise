using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class US_Chrono : MonoBehaviour
{
    [SerializeField] float chrono;
    [SerializeField] TMP_Text chronoText;

    private void Update()
    {
        if (chrono > 0)
        {
            chrono -= Time.deltaTime;
            UpdateChrono(chrono);
        }
        else
        {
            chrono = 0;
        }
    }

    private void UpdateChrono(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        chronoText.text = minutes.ToString() + ":" + seconds.ToString();
    }
}
