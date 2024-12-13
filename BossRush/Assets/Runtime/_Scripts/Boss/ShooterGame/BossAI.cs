using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;

namespace Boss
{
    public class BossAI : TreeTrunk
    {
        public Vector3[] waypoints;
        public static float moveSpeed = 5f;

        [SerializeField] private Transform playerTransform;
        [SerializeField] private GameObject projectilePrefab;

        protected override Node SetUpTree()
        {
            Node movePoints = new BossMovement(transform, waypoints);

            Node projectileFire = new ProjectileFire(transform, projectilePrefab, playerTransform, 1.5f);
            Node specialAttack = new SpecialAttack(transform, playerTransform);

             Sequence attackSequence = new Sequence(new List<Node> { projectileFire, specialAttack });
            Selector rootSelector = new Selector(new List<Node> { attackSequence, movePoints });

            return rootSelector;
        }
    }

}
