using UnityEngine;

namespace Camera
{
    public class SmoothCamera : MonoBehaviour
    {
        [Range(0,1)] [SerializeField] private float _cameraSharpness;
        [SerializeField] private Transform _target;

        private Vector3 _cameraOffset;

        private void Awake()
        {
            _cameraOffset = transform.position - _target.position;
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position + _cameraOffset, _cameraSharpness);
        }
    }
}
