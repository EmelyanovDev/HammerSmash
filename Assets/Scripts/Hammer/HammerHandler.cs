using System;
using UnityEngine;

namespace Hammer
{
    [RequireComponent(typeof(HammerPhysics))]
    
    public class HammerHandler : MonoBehaviour
    {
        private HammerPhysics _physics;
        
        public event Action HammerWasAttacked;
        
        public static event Action HammerDie;

        private void Awake()
        {
            _physics = GetComponent<HammerPhysics>();
        }

        public void AttackHammer(Vector3 enemyPosition)
        {
            HammerWasAttacked?.Invoke();
            _physics.AddForce(transform.position - enemyPosition);
        }

        public void Die()
        {
            HammerDie?.Invoke();
        }
    }
}