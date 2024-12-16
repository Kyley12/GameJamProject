using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public StatsSO playerStats;
    public StatsSO bossStats;
   
    private void Start()
    {
        ResetHealth();
        ResetShield(); 
    }

    private void ResetHealth()
    {
        playerStats.GetGeneralStatsInfo("Hp").value = playerStats.GetGeneralStatsInfo("Hp").maxValue;
        bossStats.GetGeneralStatsInfo("Hp").value = bossStats.GetGeneralStatsInfo("Hp").maxValue;
    }

    private void ResetShield()
    {
        playerStats.GetBattleStatsInfo("Shield").value = playerStats.GetBattleStatsInfo("Shield").maxValue;
        playerStats.GetBattleStatsInfo("Shield").isOn = true;
        bossStats.GetBattleStatsInfo("Shield").value = bossStats.GetBattleStatsInfo("Shield").maxValue;
        bossStats.GetBattleStatsInfo("Shield").isOn = true;
    }
}
