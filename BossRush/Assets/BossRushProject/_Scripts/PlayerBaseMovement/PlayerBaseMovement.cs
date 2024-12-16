using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBaseMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private void Start()
    {
        SetUp();
    }
    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        rb.velocity = moveDirection * moveSpeed;
    }

    private void SetUp()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
}
