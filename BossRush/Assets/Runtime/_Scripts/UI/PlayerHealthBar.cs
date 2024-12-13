using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [Header("Stats")]
    public Stats playerStats;

    public Slider slider;

    private void Update()
    {
        slider.value = playerStats.GetStats("Health").value / playerStats.GetStats("Health").maxValue;
    }
}
