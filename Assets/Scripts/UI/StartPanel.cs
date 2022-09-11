using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class StartPanel : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private HomeButton _homeButton;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _homeButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
