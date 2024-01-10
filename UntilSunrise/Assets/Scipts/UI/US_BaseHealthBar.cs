using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class US_BaseHealthBar : MonoBehaviour
{
    [SerializeField] Image bHealthBarForegroundImage;

    public void UpdateBaseHealthBar(US_BaseStats health)
    {
        bHealthBarForegroundImage.fillAmount = health.bRemainingHealthPercentage;
    }
}
