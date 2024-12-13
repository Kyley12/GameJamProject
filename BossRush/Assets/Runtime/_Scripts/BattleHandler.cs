using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform bossTransform;

    [SerializeField] private Stats playerStats;
    [SerializeField] private Stats enemyStats;

    private void Start()
    {
        ResetStats();
        SpawnCharacter(true);
        SpawnCharacter(false);
    }

    private void SpawnCharacter(bool isPlayerTeam)
    {
        Vector3 position;
        Transform currPrefab; 
        if(isPlayerTeam)
        {
            position = new Vector3(0, 0, 0);
            currPrefab = playerTransform;
        }
        else
        {
            position = new Vector3(0, 0, 10);
            currPrefab = bossTransform;
        }

        Instantiate(currPrefab, position, Quaternion.identity);
    }

    private void ResetStats()
    {
        playerStats.ModifyStats("Health", playerStats.GetStats("Health").maxValue);
        enemyStats.ModifyStats("Health", enemyStats.GetStats("Health").maxValue);
    }
}
