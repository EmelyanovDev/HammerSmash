using Hammer;
using Scene;

namespace UI
{
    public class HomeButton : RestartButton
    {
        private void OnEnable()
        {
            Finish.LevelFinished += () => gameObject.SetActive(false);
            HammerHealth.HammerDied += () => gameObject.SetActive(false);
        }
        
        private void OnDisable()
        {
            Finish.LevelFinished -= () => gameObject.SetActive(false);
            HammerHealth.HammerDied -= () => gameObject.SetActive(false);
        }
    }
}