using System.Linq;
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
            HammerHealth.HealthChanged += RemoveHeart;
        }
        
        private void OnDisable()
        {
            HammerHealth.HealthChanged -= RemoveHeart;
        }

        private void RemoveHeart(int heartsIndex)
        {
            _hearts[heartsIndex].gameObject.SetActive(false);
        }

        private void AddHeart()
        {
            var heart = _hearts.FirstOrDefault(heart => heart.gameObject.activeSelf == false);
            heart.gameObject.SetActive(true);
        }
    }
}