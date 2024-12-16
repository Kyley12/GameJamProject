using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Stats")]
public class StatsSO : ScriptableObject
{
    public List<GeneralStatsInfo> generalStatsInfos;
    public List<BattleStatsInfo> battleStatsInfos;

    public GeneralStatsInfo GetGeneralStatsInfo(string name)
    {
        return generalStatsInfos.Find(currentStat => currentStat.name == name);
    }

    public BattleStatsInfo GetBattleStatsInfo(string name)
    {
        return battleStatsInfos.Find(currentStat => currentStat.name == name);
    }

    public void ModifyGeneralStatInfo(string name, float value)
    {
        GeneralStatsInfo currentStat = GetGeneralStatsInfo(name);
        if(currentStat != null)
        {
            currentStat.value = value;
        }
        else
        {
            Debug.LogWarning("Stat not found!");
        }
    }

    public void ModifyBattleStatInfo(string name, bool isOn)
    {
        BattleStatsInfo currentStat = GetBattleStatsInfo(name);
        if(currentStat != null)
        {
            currentStat.isOn = isOn;
        }
        else
        {
            Debug.LogWarning("Stat not found!");
        }
    }

    public void ModifyBattleStatInfo(string name, float value)
    {
        BattleStatsInfo currentStat = GetBattleStatsInfo(name);
        if(currentStat != null)
        {
            currentStat.value = value;
        }
        else
        {
            Debug.LogWarning("Stat not found!");
        }
    }

    public void ModifyBattleStatInfo(string name, float value, bool isOn)
    {
        BattleStatsInfo currentStat = GetBattleStatsInfo(name);
        if(currentStat != null)
        {
            currentStat.value = value;
            currentStat.isOn = isOn;
        }
        else
        {
            Debug.LogWarning("Stat not found!");
        }
    }
}

[System.Serializable]
public class GeneralStatsInfo
{
    public string name;
    public float value;
    public float maxValue;

    public GeneralStatsInfo(string name, float value, float maxValue)
    {
        this.name = name;
        this.value = value;
        this.maxValue = maxValue;
    }
}

[System.Serializable]
public class BattleStatsInfo : GeneralStatsInfo
{
    public bool isOn;

    public BattleStatsInfo(string name, float value, float maxValue, bool isOn) : base(name, value, maxValue)
    {
        this.isOn = isOn;
    }
}