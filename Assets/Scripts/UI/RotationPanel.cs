using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class RotationPanel : MonoBehaviour, IDragHandler
    {
        public static event Action<float> PointerDragged;
        
        public void OnDrag(PointerEventData eventData)
        {
            PointerDragged?.Invoke(eventData.delta.x);
        }
    }
}