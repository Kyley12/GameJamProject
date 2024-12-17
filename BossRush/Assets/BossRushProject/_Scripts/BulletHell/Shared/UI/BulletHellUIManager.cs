using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletHellUIManager : MonoBehaviour
{
    [Header("References")]
    public StatsSO stats;
    public Slider healthBar;
    public Slider shieldBar;

    [Header("Health")]
    public float health;
    public float maxHealth;

    [Header("Shield")]
    public float shieldHealth;
    public float shieldMaxHealth;

    private void Start()
    {
        SetUp();
    }

    private void Update()
    {
        GetAllInfo();
        healthBar.value = health / maxHealth;
        shieldBar.value = shieldHealth / shieldMaxHealth;
    }

    private void GetAllInfo()
    {
        health = stats.GetGeneralStatsInfo("Hp").value;
        shieldHealth = stats.GetBattleStatsInfo("Shield").value;
    }

    private void SetUp()
    {
        maxHealth = stats.GetGeneralStatsInfo("Hp").maxValue;
        shieldMaxHealth = stats.GetBattleStatsInfo("Shield").maxValue;
    }
}
