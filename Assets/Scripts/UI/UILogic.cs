using UnityEngine;
using UnityEngine.SceneManagement;

namespace RollingBall.UI
{
    public class UILogic : MonoBehaviour
    {
        public void StartGame()
        {
            GameController.GameStart();
        }

        public void RestartGame()
        {
            GameController.RestartGame();
        }

        public void ReloadCurrentScene()
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
