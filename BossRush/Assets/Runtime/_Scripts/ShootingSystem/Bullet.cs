using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [Header("Bullet speed")]
    public float moveSpeed = 25f;
    public float timer;

    private Rigidbody bulletRb;
    private Vector3 shootingDirection;
    

    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
    }


    private void Start()
    {
        bulletRb.velocity = shootingDirection.normalized * moveSpeed;
    }

    private void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        shootingDirection = direction;
    }
}
