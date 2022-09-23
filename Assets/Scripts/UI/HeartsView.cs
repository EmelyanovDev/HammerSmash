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

        private void RemoveHeart(int heartCount)
        {
            for (int i = _hearts.Length - 1; i >= Mathf.Max(0,heartCount); i--)
                _hearts[i].gameObject.SetActive(false);
        }

        private void AddHeart()
        {
            var heart = _hearts.FirstOrDefault(heart => heart.gameObject.activeSelf == false);
            heart.gameObject.SetActive(true);
        }
    }
}