using BehaviourTree;
using UnityEngine;

namespace Boss
{
    public class ProjectileFire : Node
    {
         private Transform _bossTransform;
        private GameObject _projectilePrefab;
        private Transform _playerTransform;
        private float _fireCooldown;
        private float _lastFireTime;

        public ProjectileFire(Transform bossTransform, GameObject projectilePrefab, Transform playerTransform, float fireCooldown)
        {
            _bossTransform = bossTransform;
            _projectilePrefab = projectilePrefab;
            _playerTransform = playerTransform;
            _fireCooldown = fireCooldown;
            _lastFireTime = -fireCooldown;
        }

        public override NodeState Evalutate()
        {
            if (Time.time - _lastFireTime < _fireCooldown)
            {
                state = NodeState.Failure;
                return state;
            }

            _lastFireTime = Time.time;

            // Fire projectile at the player
            Vector3 direction = (_playerTransform.position - _bossTransform.position).normalized;
            GameObject projectile = Object.Instantiate(_projectilePrefab, _bossTransform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = direction * BossAI.projectileSpeed; // Adjust speed

            Debug.Log("Fired projectile!");

            state = NodeState.Success;
            return state;
        }
    }   
}
