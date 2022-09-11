using Hammer;
using UnityEngine;

namespace UI
{
    public class RestartPanel : MonoBehaviour
    {
        private void Start()
        {
            HammerHealth.HammerDied += () => gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnDestroy()
        {
            HammerHealth.HammerDied -= () => gameObject.SetActive(true);
        }
    }
}