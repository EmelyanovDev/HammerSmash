using System;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneSwitcher : MonoBehaviour
    {
        private void OnEnable()
        {
            RestartButton.ButtonClick += RestartScene;
        }
        
        private void OnDisable()
        {
            RestartButton.ButtonClick -= RestartScene;
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}