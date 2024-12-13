using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Stats bossStats;

    private StatsInfo bossHealth;
    
    private void Start()
    {
        bossHealth = bossStats.GetStats("Health");
    }

    private void Update()
    {
        bossHealth = bossStats.GetStats("Health");
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        slider.value = bossHealth.value / bossHealth.maxValue;
    }
}
