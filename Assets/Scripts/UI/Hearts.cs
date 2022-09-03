using System;
using UnityEngine;
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

        private void RemoveHeart()
        {
            _hearts[_heartsCount - 1].gameObject.SetActive(false);
            _heartsCount--;
        }
    }
}
