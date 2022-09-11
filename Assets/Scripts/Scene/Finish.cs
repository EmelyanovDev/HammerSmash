using System;
using UnityEngine;

namespace Scene
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private int _hammerLayer;
        
        public static event Action LevelFinished;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _hammerLayer)
            {
                LevelFinished?.Invoke();
            }
        }
    }
}
