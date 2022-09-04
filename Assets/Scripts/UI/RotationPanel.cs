using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class RotationPanel : MonoBehaviour, IDragHandler
    {
        public static event Action<Vector2> PointerDragged;
        
        public void OnDrag(PointerEventData eventData)
        {
            PointerDragged?.Invoke(eventData.delta);
        }
    }
}