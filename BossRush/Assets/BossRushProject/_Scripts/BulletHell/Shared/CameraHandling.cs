using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraHandling : MonoBehaviour
{
    public Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z - 12);
        transform.LookAt(playerTransform);
    }
}
