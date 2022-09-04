using System;
using Enemy;
using UI;
using UnityEngine;

namespace Hammer
{
    [RequireComponent(typeof(HammerPhysics))]
    
    public class HammerCollision : MonoBehaviour
    {
        private HammerPhysics _physics;
        
        public static event Action HammerWasAttacked;

        private void Awake()
        {
            _physics = GetComponent<HammerPhysics>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out EnemyMovement enemy))
            {
                HammerWasAttacked?.Invoke();
                _physics.AddForce(transform.position - enemy.transform.position);
            }
        }
    }
}