using UnityEngine;

namespace Hammer
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class HammerHead : MonoBehaviour
    {
        [SerializeField] private float _enemyBounciness;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void PushFromEnemy(Vector3 enemyPosition)
        {
            Vector3 punch = transform.position - enemyPosition;
            _rigidbody.AddForce(punch * _enemyBounciness);
        }
    }
}
