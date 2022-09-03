using System;
using UI;
using UnityEngine;

namespace Hammer
{
    public class HammerRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Rigidbody _hammerHinge;
        [SerializeField] private float _maxAngularVelocity;
        
        private void OnEnable()
        {
            RotationPanel.OnPointerDrag += Rotate;
        }
        
        private void OnDisable()
        {
            RotationPanel.OnPointerDrag -= Rotate;
        }

        private void Awake()
        {
            _hammerHinge.maxAngularVelocity = _maxAngularVelocity;
        }

        private void Rotate(Vector2 delta)
        {
            float rotation = delta.x * _rotationSpeed * Time.deltaTime;
            _hammerHinge.AddRelativeTorque(0, 0,rotation);
        }
    }
}