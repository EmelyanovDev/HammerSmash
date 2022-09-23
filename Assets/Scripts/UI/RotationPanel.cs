using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class RotationPanel : MonoBehaviour, IDragHandler
    {
        private float _screensXRatio;

        private float _defaultScreenWidth = 1920f;
            
        public static event Action<float> PointerDragged;

        private void Awake()
        {
            _screensXRatio = _defaultScreenWidth / Screen.width;
        }

        public void OnDrag(PointerEventData eventData)
        {
            PointerDragged?.Invoke(eventData.delta.x * _screensXRatio);
        }
    }
}