using System;
using UI;
using UnityEngine;

namespace Hammer
{
    public class HammerRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private HingeJoint _hingeJoint;

        private void OnEnable()
        {
            RotationPanel.OnPointerDrag += Rotate;
        }
        
        private void OnDisable()
        {
            RotationPanel.OnPointerDrag -= Rotate;
        }
        
        private void Rotate(Vector2 delta)
        {   
            float rotation = delta.x * _rotationSpeed * Time.deltaTime;
            var spring = _hingeJoint.spring;
            if (Mathf.Abs(spring.targetPosition) == 180)
                spring.targetPosition *= -1;
            spring.targetPosition += rotation;
            _hingeJoint.spring = spring;
        }
    }
}