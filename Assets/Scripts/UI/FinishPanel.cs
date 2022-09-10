using Scene;
using UnityEngine;

namespace UI
{
    public class FinishPanel : MonoBehaviour
    {
        private void Start()
        {
            Finish.LevelFinished += () => gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnDestroy()
        {
            Finish.LevelFinished -= () => gameObject.SetActive(true);
        }
    }
}
