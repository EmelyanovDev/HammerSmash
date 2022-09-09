using System.Collections;
using UnityEngine;

namespace Utilities
{
    public static class PhoneVibration
    {
        public static void Vibrate()
        {
            Handheld.Vibrate();
        }

        private static IEnumerator VibrateForTime(float time)
        {
            float currentTime = time;
            while (currentTime > 0)
            {
                Handheld.Vibrate();
                currentTime -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}