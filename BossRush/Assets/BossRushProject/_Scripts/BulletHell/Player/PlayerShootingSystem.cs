using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingSystem : MonoBehaviour
{
    public GameObject playerBulletPrefab;

    public float cooldownTime = 3f; // Time between shots in seconds

    private float nextFireTime = 0f; // Tracks when the next bullet can be shot
    public Transform firePoint;  
    public float bulletSpeed;
    public LayerMask targetLayer;

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
        // Get the mouse position in screen space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        // Perform raycast to detect where the mouse is pointing
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
        {
            targetPoint = hit.point; // Get the hit point in world space
        }
        else
        {
            // Default target point if raycast doesn't hit anything
            targetPoint = ray.GetPoint(100f);
        }

        targetPoint.y = firePoint.position.y;

        // Calculate the direction from the firePoint to the target
        Vector3 direction = (targetPoint - firePoint.position).normalized;

        // Instantiate and shoot the bullet
        GameObject bullet = Instantiate(playerBulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;

        // Optional: Rotate the bullet to face the direction it is traveling
        bullet.transform.forward = direction;
        Debug.Log("Bullet shot!");
    }
}
