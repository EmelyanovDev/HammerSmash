using System;
using UnityEngine;
using Utilities;

namespace Hammer
{
    [RequireComponent(typeof(HammerPhysics))]
    
    public class HammerHandler : MonoBehaviour
    {
        private HammerPhysics _physics;

        public event Action<int> TookDamage;

        public static event Action HammerDied;

        private void Awake()
        {
            _physics = GetComponent<HammerPhysics>();
        }

        public void TakeDamage(Vector3 enemyPosition, float punchForce, int damage)
        {
            TookDamage?.Invoke(damage);
            PhoneVibration.Vibrate();
            _physics.PushFromEnemy(enemyPosition, punchForce);
        }
        
        public void Die()
        {
            HammerDied?.Invoke();
            PhoneVibration.Vibrate();
        }

        public void ChangeHookCondition(bool condition)
        {
            _physics.SwitchPhysics(condition);
        }
    }
}