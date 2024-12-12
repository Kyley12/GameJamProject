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
    

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody>();

        bulletRb.velocity = transform.forward * moveSpeed;
    }

    private void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1)
        {
            Destroy(gameObject);
        }
    }
}
