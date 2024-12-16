using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float bulletsAmount;
    public float fireRate;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector3 bulletMoveDirection;

    private void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for(int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulletDirectionX = transform.position.x  + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirectionZ = transform.position.z + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirectionX, 0f, bulletDirectionZ);
            Vector3 bulletDirection = (bulletMoveVector - new Vector3(transform.position.x, 0f, transform.position.z)).normalized;

            GameObject bullet = BulletPool.bulletPoolInstance.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetMoveDirection(bulletDirection);

            angle += angleStep;
        }
    } 

}
