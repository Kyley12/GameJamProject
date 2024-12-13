using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public static CameraManager instance;

    private void Awake()
    {
        CameraManager.instance = this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            // Chasing player camera system
            transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        }

    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

}
