using UnityEngine;

namespace Camera
{
    public class SmoothCamera : MonoBehaviour
    {
        [Range(0,1)] [SerializeField] private float _cameraSharpness;
        [SerializeField] private Transform _target;

        private void FixedUpdate()
        {
            Vector3 target = new Vector3(_target.position.x, _target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, _cameraSharpness);
        }
    }
}
