using Hammer;
using UnityEngine;

namespace Levels
{
    public class DiePlatform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out HammerHandler handler))
                handler.Die();
        }
    }
}