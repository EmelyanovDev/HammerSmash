using UnityEngine;

namespace Hammer
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class HammerHead : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void PushFromEnemy(Vector3 enemyPosition, float force)
        {
            Vector3 punch = transform.position - enemyPosition;
            _rigidbody.AddForce(punch * force);
        }
    }
}
