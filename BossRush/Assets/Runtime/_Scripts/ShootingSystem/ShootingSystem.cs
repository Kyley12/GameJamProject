using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public Transform firePoint;     // Point where the bullet is spawned
    public float fireCooldown = 3f; // Cooldown time between shots

    private float nextFireTime = 0f;

    void Update()
    {
        // Check if the player presses the fire button and if the cooldown has elapsed
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot(firePoint.forward);
            nextFireTime = Time.time + fireCooldown; // Set the next allowed fire time
        }
    }

    private void Shoot(Vector3 shootDirection)
    {
        // Instantiate the bullet at the fire point
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Pass the direction to the bullet
        Bullet bullet = bulletInstance.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetDirection(shootDirection);
        }

        
    }
}
