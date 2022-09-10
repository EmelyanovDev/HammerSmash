using Hammer;
using UnityEngine;

namespace UI
{
    public class RestartPanel : MonoBehaviour
    {
        private void Start()
        {
            HammerHealth.HammerDie += () => gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnDestroy()
        {
            HammerHealth.HammerDie -= () => gameObject.SetActive(true);
        }
    }
}