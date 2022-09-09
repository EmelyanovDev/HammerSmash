using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class RestartButton : MonoBehaviour, IPointerClickHandler
    {
        public static event Action ButtonClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            ButtonClick?.Invoke();
        }
    }
}
