using UnityEngine;

namespace Physics
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class GravityChanging : MonoBehaviour
    {
        [SerializeField] private float _gravityAddition;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            var newVelocity = _rigidbody.velocity;
            newVelocity.y += _gravityAddition * Time.fixedDeltaTime;
            _rigidbody.velocity = newVelocity;
        }
    }
}