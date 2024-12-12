using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Movements")]
    public float moveSpeed;

    [Header("References")]
    public Rigidbody rb;
    public GameObject bulletPrefab;
    public Transform gunPosition;

    [Header("Inputs")]
    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    [Header("Cooltime")]
    public float timer = 3f;
    public float coolTime = 3f;

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

        if(Input.GetMouseButton(0) && Time.time >= timer)
        {
            Shoot();
        }
       
    }

    private void MovePlayer()
    {
        moveDirection = horizontalInput * transform.right + verticalInput * transform.forward;

        rb.velocity = moveDirection * moveSpeed;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
        timer = Time.time + coolTime;
    }
}
