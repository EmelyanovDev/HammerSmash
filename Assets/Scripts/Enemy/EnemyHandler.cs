using Hammer;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyAnimation))]
    [RequireComponent(typeof(EnemyMovement))]
    
    public class EnemyHandler : MonoBehaviour
    {
        [SerializeField] private Collider[] _colliders;
        [SerializeField] private int _heartsCount = 1;
        [SerializeField] private float _destroyDelay = 0.5f;

        private EnemyHead _head;
        private EnemyAnimation _animation;
        private EnemyMovement _movement;
        private bool _isDie;

        private void Awake()
        {
            _animation = GetComponent<EnemyAnimation>();
            _head = GetComponentInChildren<EnemyHead>();
            _movement = GetComponent<EnemyMovement>();
        }

        private void OnEnable()
        {
            _head.HeadHit += ReduceHealth;
        }
        
        private void OnDisable()
        {
            _head.HeadHit -= ReduceHealth;
        }

        private void ReduceHealth(float hammerVelocity)
        {
            _heartsCount--;
            if(_heartsCount == 0)
                Die();
        }

        private void Die()
        {
            _isDie = true;
            foreach (var collider in _colliders)
                collider.enabled = false;
            _animation.PlayDieAnimation();
            _movement.DeactivateAgent();
            Destroy(gameObject, _destroyDelay);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HammerHandler hammer))
            {
                if (_isDie) return;
                hammer.AttackHammer(transform.position);
                _animation.PlayPunchAnimation();
            }
        }
    }
}