using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 moveDirection;
    public float moveSpeed;
    public float destroyTime;

    private void OnEnable()
    {
        Invoke("Destroy", destroyTime);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveBullet();
    }

    public void SetMoveDirection(Vector3 dir)
    {
        moveDirection = dir;
    }

    private void MoveBullet()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
