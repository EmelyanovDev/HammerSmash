using Scene;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class RestartButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneLoader.RestartScene();
        }
    }
}
