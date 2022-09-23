using UnityEngine;
using UnityEngine.EventSystems;

namespace Shop
{
    public class ProductButton : MonoBehaviour, IPointerClickHandler
    {
        private ProductHandler _handler;

        public void Init(ProductHandler handler)
        {
            _handler = handler;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _handler.Click();
        }
    }
}