using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TreeNode/Action/ShipMovement")]
public class ShipMovement : TreeNode
{
    public Vector3 centerPoint; // Center of the movement range
    public float movementRadius = 10f; // Circular range radius
    public float moveSpeed = 5f; // Speed of movement
    public float directionChangeInterval = 3f; // Time to choose a new direction

    private Vector3 moveDirection; // Current movement direction
    private float timer; // Timer for direction changes


    public override bool Execute(BossAI bossAI)
    {
        if (centerPoint == Vector3.zero)
        {
            centerPoint = bossAI.transform.position;
            ChooseRandomDirection();
        }

        bossAI.transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Check if the boss is out of bounds
        if (Vector3.Distance(bossAI.transform.position, centerPoint) > movementRadius)
        {
            // Reflect the direction back toward the center
            Vector3 toCenter = centerPoint - bossAI.transform.position;
            toCenter.y = 0; // Ensure Y-axis is ignored
            toCenter = toCenter.normalized;
            moveDirection = Vector3.Lerp(moveDirection, toCenter, 0.5f).normalized;

            Debug.Log("Boss returning to center!");
        }

        // Update timer for changing direction
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            ChooseRandomDirection();
            bossAI.StartCoroutine(RandomPause());
            timer = directionChangeInterval;
        }

        return true;
    }

    private void ChooseRandomDirection()
    {
        // Generate a random horizontal direction (X and Z axes)
        moveDirection = Random.insideUnitSphere;
        moveDirection.y = 0; // Keep the movement on the ground plane
        moveDirection.Normalize();

        Debug.Log($"New Direction: {moveDirection}");
    }

    IEnumerator RandomPause()
    {
        moveDirection = Vector3.zero; // Stop moving
        yield return new WaitForSeconds(Random.Range(0.25f, 1f)); // Random pause duration
        ChooseRandomDirection();
    }
}
