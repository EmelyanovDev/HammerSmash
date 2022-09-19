using System;
using UnityEngine;

namespace Money
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _hammerLayer;
        [SerializeField] private int _takingDestroyDelay;

        private bool _isPicked;
        
        public event Action CoinPicked;

        private void OnTriggerEnter(Collider other)
        {
            if (_isPicked == false && other.gameObject.layer == _hammerLayer)
            {
                _isPicked = true;
                //play picking animation and sound
                Destroy(gameObject, _takingDestroyDelay);
                CoinPicked?.Invoke();
            }
        }
    }
}