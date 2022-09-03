using System;
using UI;
using UnityEngine;

namespace Hammer
{
    public class HammerRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private HingeJoint _hingeJoint;
        [SerializeField] private Rigidbody _hammer;
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
            
        }

        private void Rotate(Vector2 delta)
        {   
            _hammer.maxAngularVelocity = _maxAngularVelocity;
            float rotation = delta.x * _rotationSpeed * Time.deltaTime;
            _hammer.AddRelativeTorque(0, 0,rotation);
            
            // var spring = _hingeJoint.spring;
            // if (Mathf.Abs(spring.targetPosition) == 180)
            //     spring.targetPosition *= -1;
            // spring.targetPosition += rotation;
            // _hingeJoint.spring = spring;
        }
    }
}