using System;
using UnityEngine;

namespace Hammer
{
    [RequireComponent(typeof(HammerHandler))]
    
    public class HammerHealth : MonoBehaviour
    {
        [SerializeField] private int _heartsCount;

        private HammerHandler _handler;
        
        public static event Action<int> HealthChanged;
        
        public static event Action HammerDied;

        private void Awake()
        {
            _handler = GetComponent<HammerHandler>();
        }

        private void OnEnable()
        {
            _handler.TookDamage += RemoveHeart;
        }
        
        private void OnDisable()
        {
            _handler.TookDamage -= RemoveHeart;
        }

        private void RemoveHeart()
        {
            _heartsCount--;
            HealthChanged?.Invoke(_heartsCount);
            if (_heartsCount == 0)
                HammerDied?.Invoke();
        }
    }
}
