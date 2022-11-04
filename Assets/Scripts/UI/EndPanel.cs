using Hammer;
using Scene;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities;

namespace UI
{
    public class EndPanel : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text _tapToPlayText;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private GameObject _nextLevelButton;
        [SerializeField] private HomeButton _homeButton;

        private bool _isClicked;
        
        private void Start()
        {
            TimeHandler.Pause();
            
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
            if (_isClicked) return;
            
            TimeHandler.SwitchPause();
            _tapToPlayText.gameObject.SetActive(false);
            _homeButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
            _isClicked = true;
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