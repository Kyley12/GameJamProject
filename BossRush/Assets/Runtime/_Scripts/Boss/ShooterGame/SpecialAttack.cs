using UnityEngine;
using BehaviourTree;

namespace Boss
{
    public class SpecialAttack : Node
    {
        private Transform _bossTransform;
        private Transform _playerTransform;

        public SpecialAttack(Transform bossTransform, Transform playerTransform)
        {
            _bossTransform = bossTransform;
            _playerTransform = playerTransform;
        }

        public override NodeState Evalutate()
        {
            // Special attack logic (e.g., firing a laser or spawning minions)
            Debug.Log("Performing special attack!");
            state = NodeState.Success;
            return state;
        }
    }
}
