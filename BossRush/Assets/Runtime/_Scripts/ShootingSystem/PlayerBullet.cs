using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBullet : MonoBehaviour
{
    [Header("References")]
    public Stats playerStats;
    public Stats bossStats;
    private Rigidbody bulletRb;
    private Vector3 shootingDirection;

    [Header("Bullet speed")]
    public float moveSpeed = 30f;
    
    [Header("Health")]
    public StatsInfo bossHealth;

    [Header("Damage")]
    public StatsInfo playerDamage;

    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
    }


    private void Start()
    {
        bulletRb.velocity = shootingDirection.normalized * moveSpeed;
        
        playerDamage = playerStats.GetStats("Damage");
        bossHealth = bossStats.GetStats("Health");
    }

    private void Update()
    {
        Vector3 screenPosition = UnityEngine.Camera.main.WorldToViewportPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        shootingDirection = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            TakeDamage();
            Destroy(gameObject);
        }
        else if(other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage()
    {
        bossHealth.value -= playerDamage.value;
        bossStats.ModifyStats("Health", bossHealth.value);
    }
}
