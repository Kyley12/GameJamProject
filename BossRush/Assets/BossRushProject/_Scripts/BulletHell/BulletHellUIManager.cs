using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletHellUIManager : MonoBehaviour
{
    [Header("References")]
    public StatsSO bossStats;
    public Slider healthBar;
    public Slider shieldBar;

    [Header("Health")]
    public float bossHealth;
    public float bossMaxHealth;

    [Header("Shield")]
    public float bossShieldHealth;
    public float bossShieldMaxHealth;

    private void Start()
    {
        SetUp();
    }

    private void Update()
    {
        GetAllInfo();
        healthBar.value = bossHealth / bossMaxHealth;
        shieldBar.value = bossShieldHealth / bossShieldMaxHealth;
    }

    private void GetAllInfo()
    {
        bossHealth = bossStats.GetGeneralStatsInfo("Hp").value;
        bossShieldHealth = bossStats.GetBattleStatsInfo("Shield").value;
    }

    private void SetUp()
    {
        bossMaxHealth = bossStats.GetGeneralStatsInfo("Hp").maxValue;
        bossShieldMaxHealth = bossStats.GetBattleStatsInfo("Shield").maxValue;
    }
}
