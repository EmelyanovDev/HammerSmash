using Hammer;
using Scene;

namespace UI
{
    public class HomeButton : RestartButton
    {
        private void OnEnable()
        {
            Finish.LevelFinished += Deacivate;
            HammerHandler.HammerDied += Deacivate;
        }
        
        private void OnDisable()
        {
            Finish.LevelFinished -= Deacivate;
            HammerHandler.HammerDied -= Deacivate;
        }

        private void Deacivate() => gameObject.SetActive(false);
    }
}