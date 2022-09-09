using System;
using Hammer;
using UnityEngine;

namespace Enemy
{
    public class EnemyHead : MonoBehaviour
    {
        public event Action<float> HeadHit;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent(out HammerHead head))
                HeadHit?.Invoke(head.YVelocity);
        }

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.TryGetComponent(out HammerHead head))
                HeadHit?.Invoke(head.YVelocity);
        }
    }
}
