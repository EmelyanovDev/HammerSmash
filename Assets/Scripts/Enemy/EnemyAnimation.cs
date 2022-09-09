using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Animator))]
    
    public class EnemyAnimation : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void DeactivateAnimator()
        {
            _animator.enabled = false;
        }

        public void PlayPunchAnimation()
        {
            _animator.Play("EnemyPunching");
        }

        public void PlayDieAnimation()
        {
            _animator.Play("EnemyDying");
        }
    }
}