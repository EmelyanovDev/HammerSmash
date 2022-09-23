using System;
using UnityEngine;

namespace Scene
{
    public class Finish : MonoBehaviour
    {
        private int _hammerLayer = 6;
        
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
