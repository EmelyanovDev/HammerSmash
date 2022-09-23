using Hammer;
using UnityEngine;

namespace Enemy
{
    public class EnemyCollision : MonoBehaviour
    {
        private EnemyHandler _handler;

        private void Awake()
        {
            _handler = GetComponent<EnemyHandler>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HammerHandler hammer))
                _handler.AttackHammer(hammer);
        }
    }
}