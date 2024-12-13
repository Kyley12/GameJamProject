using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Stats")]
    public Stats playerStats;
    public Stats bossStats;

    [Header("Health")]
    public StatsInfo playerHealth;

    [Header("Damage")]
    public StatsInfo bossDamage;

    private void Start()
    {
        playerHealth = playerStats.GetStats("Health");
        bossDamage = bossStats.GetStats("Damage");
    }
    private void Update()
    {
        Vector3 screenPosition = UnityEngine.Camera.main.WorldToViewportPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            TakeDamage();
            Destroy(gameObject);
        }
        else if(other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage()
    {
        playerHealth.value -= bossDamage.value;
        playerStats.ModifyStats("Health", playerHealth.value);
    }
}
