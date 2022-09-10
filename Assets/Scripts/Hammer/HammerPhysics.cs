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

        public void PushFromEnemy(Vector3 enemyPosition, float force)
        {
            Vector3 punch = transform.position - enemyPosition;
            _rigidbody.AddForce(punch * force);
        }
    }
}