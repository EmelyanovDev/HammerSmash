using UnityEngine;

namespace Camera
{
    public class SmoothCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
    
        [Range(0,1)] [SerializeField] private float _cameraSharpness;

        private void FixedUpdate()
        {
            Vector3 target = new Vector3(_target.position.x, _target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, _cameraSharpness);
        }
    }
}
