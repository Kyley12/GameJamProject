using BehaviourTree;
using UnityEngine;

namespace Boss
{
    public class BossAI : TreeTrunk
    {
        public Vector3[] waypoints;
        public static float moveSpeed = 5f;

        protected override Node SetUpTree()
        {
            Node root = new BossMovement(transform, waypoints);
            return root;
        }
    }

}
