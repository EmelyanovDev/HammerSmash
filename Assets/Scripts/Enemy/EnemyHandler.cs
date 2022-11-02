using System;
using Hammer;
using UnityEngine;
using Audio;

namespace Enemy
{
    [RequireComponent(typeof(EnemyAnimation))]
    [RequireComponent(typeof(EnemyMovement))]
    
    public class EnemyHandler : MonoBehaviour
    {
        [SerializeField] private Collider[] _colliders;
        [SerializeField] private float _attackPunchForce;
        [SerializeField] private float _dyingDestroyDelay = 0.6f;
        [SerializeField] private float _takingDamageTime = 0.5f;
        [SerializeField] private int _damageCount;
        
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
                _movement.TurnAgent(false);
                _animation.DisableWalking();
            }
        }

        public void TakeDamage(HammerHead head)
        {
            SoundEffects._instance.PlayEnemyTakeDamageSound();
            _animation.PlayDizzy();
            _movement.DisableAgentForSeconds(_takingDamageTime);
            head.PushFromEnemy(transform.position);
            TookDamage?.Invoke();
        }

        public void Die()
        {
            SoundEffects._instance.PlayEnemyDieSound();
            _isDie = true;
            _animation.PlayDie();
            _movement.TurnAgent(false);
            TurnColliders(false);
            Destroy(gameObject, _dyingDestroyDelay);
        }

        private void TurnColliders(bool condition)
        {
            foreach (var collider in _colliders)
                collider.enabled = condition;
        }

        public void AttackHammer(HammerHandler hammer)
        {
            if (_isDie) return;
            hammer.TakeDamage(transform.position, _attackPunchForce, _damageCount);
            _animation.PlayPunch();
            SoundEffects._instance.PlayEnemyAttackSound();
        }
    }
}