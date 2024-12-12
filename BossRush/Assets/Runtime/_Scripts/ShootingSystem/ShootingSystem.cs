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
            Shoot();
            nextFireTime = Time.time + fireCooldown; // Set the next allowed fire time
        }
    }

    private void Shoot()
    {
        // Instantiate the bullet at the fire point
        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Set the shooting direction based on the player's forward direction
        Vector3 shootDirection = firePoint.forward;

        // Pass the direction to the bullet
        Bullet bullet = bulletInstance.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.SetDirection(shootDirection);
        }

        Debug.Log("Bullet shot!");
    }
}
