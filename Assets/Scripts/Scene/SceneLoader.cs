using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneLoader : MonoBehaviour
    {
        private const string SceneKey = "Scene";

        private void Start()
        {
            if (PlayerPrefs.HasKey(SceneKey))
                SceneManager.LoadScene(PlayerPrefs.GetInt(SceneKey));
        }

        public static void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public static void LoadNextScene()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
                return;
            PlayerPrefs.SetInt(SceneKey, nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}