using UnityEngine;

namespace Hammer
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class HammerPhysics : MonoBehaviour
    {
        [SerializeField] private Transform _centerOfMass;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.centerOfMass = Vector3.Scale(_centerOfMass.localPosition, transform.localScale);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if(_rigidbody)
                Gizmos.DrawSphere(_rigidbody.worldCenterOfMass, 0.1f);
        }
    }
}