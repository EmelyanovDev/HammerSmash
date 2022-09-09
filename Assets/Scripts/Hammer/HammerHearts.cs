using System;
using UnityEngine;

namespace Hammer
{
    [RequireComponent(typeof(HammerHandler))]
    
    public class HammerHearts : MonoBehaviour
    {
        [SerializeField] private int _heartsCount;

        private HammerHandler _handler;
        
        public static event Action<int> HeartsChanged;

        private void Awake()
        {
            _handler = GetComponent<HammerHandler>();
        }

        private void OnEnable()
        {
            _handler.HammerWasAttacked += RemoveHeart;
        }
        
        private void OnDisable()
        {
            _handler.HammerWasAttacked -= RemoveHeart;
        }

        private void RemoveHeart()
        {
            _heartsCount--;
            HeartsChanged?.Invoke(_heartsCount);
            if (_heartsCount == 0)
                _handler.Die();
        }
    }
}
