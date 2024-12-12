using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Movements")]
    public float moveSpeed;

    [Header("References")]
    public Rigidbody rb;
    public Transform gunPosition;

    [Header("Inputs")]
    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
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
        moveDirection = horizontalInput * transform.right + verticalInput * transform.forward;

        rb.velocity = moveDirection * moveSpeed;
    }
}
