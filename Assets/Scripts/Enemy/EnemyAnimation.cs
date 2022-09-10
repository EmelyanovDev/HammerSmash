using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Animator))]
    
    public class EnemyAnimation : MonoBehaviour
    {
        private Animator _animator;
        private readonly int _isWalking = Animator.StringToHash("IsWalking");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void DisableWalking()
        {
            _animator.SetBool(_isWalking, false);
            _animator.Play("EnemyIdle");
        }

        public void PlayPunch()
        {
            _animator.Play("EnemyPunching");
        }

        public void PlayDie()
        {
            _animator.Play("EnemyDying");
        }
    }
}