using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Patterns")]
public class BossPatterns : ScriptableObject
{
    public List<PatternsInfo> patterns;
    
}

[System.Serializable]
public class PatternsInfo
{
    public float bulletsAmount;
    public float fireRate;
    public float startAngle;
    public float endAngle;

    public PatternsInfo(float bulletsAmount, float fireRate, float startAngle, float endAngle)
    {
        this.bulletsAmount = bulletsAmount;
        this.fireRate = fireRate;
        this.startAngle = startAngle;
        this.endAngle = endAngle;
    }
}
