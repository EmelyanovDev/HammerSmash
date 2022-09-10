using System;
using Hammer;
using UnityEngine;

namespace Scene
{
    public class Finish : MonoBehaviour
    {
        public static event Action LevelFinished;

        private void OnCollisionEnter(Collision other)
        {
            print("A");
            if (other.gameObject.TryGetComponent(out HammerHandler hammer))
            {
                print("B");
                LevelFinished?.Invoke();
            }
        }
    }
}
