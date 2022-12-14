using UI;
using UnityEngine;

namespace Hammer
{
    public class HammerRotation : MonoBehaviour
    {
        [SerializeField] private Rigidbody _hammerHinge;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _maxAngularVelocity;

        private void Awake()
        {
            _hammerHinge.maxAngularVelocity = _maxAngularVelocity;
        }
        
        private void OnEnable()
        {
            RotationPanel.PointerDragged += Rotate;
        }
        
        private void OnDisable()
        {
            RotationPanel.PointerDragged -= Rotate;
        }
        
        private void Rotate(float xDelta)
        {
            float rotation = xDelta * _rotationSpeed * Time.deltaTime;
            _hammerHinge.AddRelativeTorque(0, 0,rotation);
        }
    }
}