using System.Collections;
using System.Collections.Generic;
using Codice.Client.Common.GameUI;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform playerTransform;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
    }
}
