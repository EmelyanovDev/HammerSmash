using Hammer;
using Scene;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class EndPanel : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text _tapToPlayText;
        [SerializeField] private RestartButton _restartButton;
        [SerializeField] private NextLevelButton _nextLevelButton;
        [SerializeField] private HomeButton _homeButton;
        
        private void Start()
        {
            HammerHandler.HammerDied += RestartLevel;
            Finish.LevelFinished += NextLevel;
        }

        private void OnDestroy()
        {
            HammerHandler.HammerDied -= RestartLevel;
            Finish.LevelFinished -= NextLevel;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _tapToPlayText.gameObject.SetActive(false);
            _homeButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        
        private void RestartLevel()
        {
            gameObject.SetActive(true);
            _restartButton.gameObject.SetActive(true);
        }

        private void NextLevel()
        {
            gameObject.SetActive(true);
            _nextLevelButton.gameObject.SetActive(true);
        }
    }
}