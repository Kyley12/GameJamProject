using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [Header("References")]
    public StatsSO playerStats;
    public StatsSO bossStats;

    [Header("Who am I")]
    public bool amIPlayer;

    [Header("Result")]
    public bool didWin;

    [Header("Player Health/Shield/ShieldHealth/Damage")]
    public float playerHealth;
    public bool isPlayerShieldOn;
    public float playerShieldHealth;
    public float playerDamage;

    [Header("Boss Health/Shield/ShieldHealth/Damage")]
    public float bossHealth;
    public bool isBossShieldOn;
    public float bossShieldHealth;
    public float bossDamage;


    private void Update()
    {
        if(!amIPlayer)
        {
            PlayerHealthManager();
        }
        else
        {
            BossHealthManager();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !amIPlayer)
        {
            DealDamageToPlayer();
        }
        else if(other.CompareTag("Boss") && amIPlayer)
        {
            DealDamageToBoss();
            Destroy(gameObject);
        }
    }

    private void PlayerHealthManager()
    {
        if(playerStats.GetGeneralStatsInfo("Hp").value <= 0)
        {
            didWin = false;
            RoundOver();
        }
    }

    private void BossHealthManager()
    {
        if(bossStats.GetGeneralStatsInfo("Hp").value <= 0)
        {
            didWin = true;
            RoundOver();
        }
    }
    private void DealDamageToPlayer()
    {
        playerHealth = playerStats.GetGeneralStatsInfo("Hp").value;
        isPlayerShieldOn = playerStats.GetBattleStatsInfo("Shield").isOn;
        playerShieldHealth = playerStats.GetBattleStatsInfo("Shield").value;
        bossDamage = bossStats.GetGeneralStatsInfo("Damage").value;

        if(isPlayerShieldOn)
        {
            if(playerShieldHealth <= 0)
            {
                isPlayerShieldOn = false;
                playerStats.GetBattleStatsInfo("Shield").isOn = isPlayerShieldOn;
                return;
            }
            else
            {
                playerStats.ModifyBattleStatInfo("Shield", playerShieldHealth - bossDamage);
            }
        }
        else if(!isPlayerShieldOn)
        {
            playerStats.ModifyGeneralStatInfo("Hp", playerHealth - bossDamage);
        }
    }

    private void DealDamageToBoss()
    {
        bossHealth = bossStats.GetGeneralStatsInfo("Hp").value;
        isBossShieldOn = bossStats.GetBattleStatsInfo("Shield").isOn;
        bossShieldHealth = bossStats.GetBattleStatsInfo("Shield").value;
        playerDamage = playerStats.GetGeneralStatsInfo("Damage").value;

        if(isBossShieldOn)
        {
            if(bossShieldHealth <= 0)
            {
                isBossShieldOn = false;
                bossStats.GetBattleStatsInfo("Shield").isOn = isBossShieldOn;
                return;
            }
            else
            {
                bossStats.ModifyBattleStatInfo("Shield", bossShieldHealth - playerDamage);
            }
        }
        else if(!isBossShieldOn)
        {
            bossStats.ModifyGeneralStatInfo("Hp", bossHealth - playerDamage);
        }
    }

    private void RoundOver()
    {
        Debug.Log("Round win result: " + didWin);
    }
}
