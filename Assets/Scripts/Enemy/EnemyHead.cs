using Hammer;
using UnityEngine;

namespace Enemy
{
    public class EnemyHead : MonoBehaviour
    {
        private EnemyHandler _handler;

        private void Awake()
        {
            _handler = GetComponentInParent<EnemyHandler>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent(out HammerHead head))
                _handler.TakeDamage(head);
        }
    }
}
