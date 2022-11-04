using System;
using Hammer;
using UnityEngine;
using Audio;
using Money;

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
        [SerializeField] private int _coinsCount;
        
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
            _animation.PlayDizzy();
            _movement.DisableAgentForSeconds(_takingDamageTime);
            head.PushFromEnemy(transform.position);
            TookDamage?.Invoke();
            SoundEffects.Instance.PlayEnemyTakeDamageSound();
        }

        public void Die()
        {
            Wallet.ChangeMoneyCount(_coinsCount);
            _isDie = true;
            _animation.PlayDie();
            _movement.TurnAgent(false);
            SwitchColliders(false);
            Destroy(gameObject, _dyingDestroyDelay);
            SoundEffects.Instance.PlayEnemyDieSound();

        }

        private void SwitchColliders(bool condition)
        {
            foreach (var col in _colliders)
                col.enabled = condition;
        }

        public void AttackHammer(HammerHandler hammer)
        {
            if (_isDie) return;
            hammer.TakeDamage(transform.position, _attackPunchForce, _damageCount);
            _animation.PlayPunch();
            SoundEffects.Instance.PlayEnemyAttackSound();
        }
    }
}