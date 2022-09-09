using Hammer;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HeartsView : MonoBehaviour
    {
        [SerializeField] private Image[] _hearts;

        private void OnEnable()
        {
            HammerHearts.HeartsChanged += DeactivateHeart;
        }
        
        private void OnDisable()
        {
            HammerHearts.HeartsChanged -= DeactivateHeart;
        }

        private void DeactivateHeart(int heartsIndex)
        {
            _hearts[heartsIndex].gameObject.SetActive(false);
        }
    }
}