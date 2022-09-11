using System;
using Hammer;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyAnimation))]
    [RequireComponent(typeof(EnemyMovement))]
    
    public class EnemyHandler : MonoBehaviour
    {
        [SerializeField] private Collider[] _colliders;
        [SerializeField] private float _hammerPunchForce;
        [SerializeField] private float _dieDestroyDelay = 0.6f;
        
        private EnemyAnimation _animation;
        private EnemyMovement _movement;
        private bool _isDie;

        public event Action TookDamage;

        private void Awake()
        {
            _animation = GetComponent<EnemyAnimation>();
            _movement = GetComponent<EnemyMovement>();
        }

        private void Start()
        {
            if (_movement.HaveWayPoints == false)
            {
                _movement.DisableAgent();
                _animation.DisableWalking();
            }
        }

        public void TakeDamage(HammerHead head)
        {
            head.PushFromEnemy(transform.position);
            TookDamage?.Invoke();
        }

        public void Die()
        {
            _isDie = true;
            foreach (var collider in _colliders)
                collider.enabled = false;
            _animation.PlayDie();
            _movement.DisableAgent();
            Destroy(gameObject, _dieDestroyDelay);
        }

        public void AttackHammer(HammerHandler hammer)
        {
            if (_isDie) return;
            hammer.TakeDamage(transform.position, _hammerPunchForce);
            _animation.PlayPunch();
        }
    }
}