using System;
using Hammer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class Hearts : MonoBehaviour
    {
        [SerializeField] private Image[] _hearts;

        private int _heartsCount;

        private void Awake()
        {
            _heartsCount = _hearts.Length;
        }

        private void OnEnable()
        {
            HammerCollision.HammerWasAttacked += RemoveHeart;
        }
        
        private void OnDisable()
        {
            HammerCollision.HammerWasAttacked -= RemoveHeart;
        }

        public void RemoveHeart()
        {
            _heartsCount--;
            _hearts[_heartsCount].gameObject.SetActive(false);
            if (_heartsCount == 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
