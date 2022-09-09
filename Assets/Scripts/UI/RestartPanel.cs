using Hammer;
using UnityEngine;

namespace UI
{
    public class RestartPanel : MonoBehaviour
    {
        private void Start()
        {
            HammerHandler.HammerDie += () => gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnDestroy()
        {
            HammerHandler.HammerDie -= () => gameObject.SetActive(true);
        }
    }
}