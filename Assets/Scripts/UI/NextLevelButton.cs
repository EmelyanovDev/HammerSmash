using Scene;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class NextLevelButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneLoader.LoadNextScene();
        }
    }
}