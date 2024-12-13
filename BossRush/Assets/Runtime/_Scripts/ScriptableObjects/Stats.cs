using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Stats")]
public class Stats : ScriptableObject
{
    public List<StatsInfo> stats;

    public StatsInfo GetStats(string name)
    {
        return stats.Find(stat => stat.name == name);
    }

    public void AddStats(string name, float value, float maxValue)
    {
        if(GetStats(name) != null)
        {
            Debug.LogWarning($"Stat with name: {name} already exists!");
            return;
        }
        else
        {
            stats.Add(new StatsInfo(name, value, maxValue));
            Debug.Log($"Successfully added stat with name: {name} with value: {value} with max value: {maxValue}!");
        }
    }

    public void RemoveStats(string name)
    {
        StatsInfo currStat = GetStats(name);
        if(currStat != null)
        {
            stats.Remove(currStat);
            Debug.Log($"Successfully removed stat with name: {name}!");
        }
        else
        {
            Debug.LogWarning($"Stat with name: {name} not found!");
        }
    }

    public void ModifyStats(string name, float value)
    {
        StatsInfo currStat = GetStats(name);

        if(currStat != null)
        {
            currStat.value = Mathf.Clamp(value , 0f, currStat.maxValue);
            Debug.Log($"Stat with name: {name}'s value has been modified into {currStat.value}");
        }
        else
        {
            Debug.LogError($"Stat with name {name} not found!");
        }
    }
}

[System.Serializable]
public class StatsInfo
{
    public string name;
    public float value;
    public float maxValue;

    public StatsInfo(string name, float value, float maxValue)
    {
        this.name = name;
        this.value = value;
        this.maxValue = maxValue;
    }
}