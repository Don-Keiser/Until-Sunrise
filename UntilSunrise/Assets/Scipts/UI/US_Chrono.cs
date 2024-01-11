using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class US_Chrono : MonoBehaviour
{
    [SerializeField] TMP_Text chronoText;

    [SerializeField] float chrono;
    [SerializeField] float chronoIntensity1;
    [SerializeField] float chronoIntensity2;
    [SerializeField] float chronoIntensity3;
    [SerializeField] float chronoIntensity4;
    private int intensity = 0;


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
            US_WinLoseManager.instance.hasWon = true;
        }

        WaveIntensity();
    }

    private void WaveIntensity()
    {
        if (IsBetween(chrono, chronoIntensity1, chronoIntensity2) && intensity == 0)
        {
            SetSpawnInterval(1.5f, "Intensity 1");
            intensity = 1;
        }
        else if (IsBetween(chrono, chronoIntensity2, chronoIntensity3) && intensity == 1)
        {
            SetSpawnInterval(1f, "Intensity 2");
            intensity = 2;
        }
        else if (IsBetween(chrono, chronoIntensity3, chronoIntensity4) && intensity == 2)
        {
            SetSpawnInterval(0.5f, "Intensity 3");
            intensity = 3;

        }
        else if (IsBetween(chrono, chronoIntensity4, 0) && intensity == 3)
        {
            SetSpawnInterval(0.25f, "Intensity 4");
            intensity = 4;
        }
    }

    private bool IsBetween(float value, float upper, float lower)
    {
        return value <= upper && value >= lower;
    }

    public void SetSpawnInterval(float interval, string intensityMessage)
    {
        US_EnemySpawner.instance.spawnInterval = interval;
        Debug.Log(intensityMessage);
    }

    private void UpdateChrono(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        chronoText.text = minutes.ToString() + ":" + seconds.ToString();
    }
}
