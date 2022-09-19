using System;
using UnityEngine;
using Utilities;

namespace Hammer
{
    [RequireComponent(typeof(HammerPhysics))]
    
    public class HammerHandler : MonoBehaviour
    {
        private HammerPhysics _physics;
        
        public event Action TookDamage;

        private void Awake()
        {
            _physics = GetComponent<HammerPhysics>();
        }

        public void TakeDamage(Vector3 enemyPosition, float punchForce)
        {
            TookDamage?.Invoke();
            PhoneVibration.Vibrate();
            _physics.PushFromEnemy(enemyPosition, punchForce);
        }
    }
}