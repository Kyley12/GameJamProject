using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatManager : MonoBehaviour
{
    [Header("Stats")]
    public Stats bossStats;

    [Header("Health")]
    private StatsInfo health;

    private void Start()
    {
        health = bossStats.GetStats("Health");
    }
    private void Update()
    {
        health = bossStats.GetStats("Health");
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(health.value <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
