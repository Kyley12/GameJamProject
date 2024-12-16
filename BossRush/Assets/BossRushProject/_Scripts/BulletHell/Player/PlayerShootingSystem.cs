using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingSystem : MonoBehaviour
{
    public GameObject playerBulletPrefab;

    public float cooldownTime = 3f; // Time between shots in seconds

    private float nextFireTime = 0f; // Tracks when the next bullet can be shot
    public Transform firePoint;  

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + cooldownTime;
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point
        GameObject bullet = Instantiate(playerBulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("Bullet shot!");
    }
}
