using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSprial : MonoBehaviour
{
    private float angle = 0f;

    private void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    private void Fire()
    {
        for(int i = 0; i <= 1; i++)
        {
            float bulletDirectionX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulletDirectionZ = transform.position.z + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirectionX, 0f, bulletDirectionZ);
            Vector3 bulletDirection = (bulletMoveVector - new Vector3(transform.position.x, 0f, transform.position.z)).normalized;

            GameObject bullet = BulletPool.bulletPoolInstance.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().SetMoveDirection(bulletDirection);
        }

        angle += 10f;

        if(angle >= 360)
        {
            angle = 0f;
        }
    }
}
