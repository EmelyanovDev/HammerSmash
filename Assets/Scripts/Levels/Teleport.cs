using UnityEngine;

namespace Levels
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private Transform _teleportPoint;
        
        private int _hammerLayer = 6;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _hammerLayer)
                other.transform.position = _teleportPoint.position;
        }
    }
}
