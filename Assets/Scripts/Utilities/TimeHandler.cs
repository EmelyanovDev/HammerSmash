using UnityEngine;

namespace Utilities
{
    public static class TimeHandler
    {
        public static void SwitchPause()
        {
            Time.timeScale = Time.timeScale == 1f ? 0f : 1f;
        }

        public static void Pause() => Time.timeScale = 0f;
    }
}