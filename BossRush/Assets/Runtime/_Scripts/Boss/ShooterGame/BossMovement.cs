using BehaviourTree;
using UnityEngine;

namespace Boss
{
    public class BossMovement : Node
    {
        private Transform _transform;
        private Vector3[] _waypoints;
        private int currentWaypoint = 0;

        public BossMovement(Transform transform, Vector3[] waypoints)
        {
            _transform = transform;
            _waypoints = waypoints;
        }
        public override NodeState Evalutate()
        {

            if(_waypoints.Length == 0)
            {
                state = NodeState.Failure;
                return state;
            }

            Vector3 target = _waypoints[currentWaypoint];

            _transform.position = Vector3.MoveTowards(_transform.position, target, BossAI.moveSpeed * Time.deltaTime);

            if (_transform.position == target)
            {
                currentWaypoint = Random.Range(0, _waypoints.Length);
            }

            state = NodeState.Running;
            return state;
        }

    }
}
