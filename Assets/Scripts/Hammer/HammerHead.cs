using UnityEngine;

namespace Hammer
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class HammerHead : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        public float YVelocity => _rigidbody.velocity.y;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}
