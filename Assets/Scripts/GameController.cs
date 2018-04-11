using UnityEngine;

namespace RollingBall
{
    public class GameController : MonoBehaviour
    {
        public delegate void Func();

        public static event Func OnGameStart;
        public static event Func OnGameOver;

        bool isGameStart;

        public void GameStart()
        {
            isGameStart = true;
            _FireEvent_OnGameStart();
        }

        public void GameOver()
        {
            isGameStart = false;
            _FireEvent_OnGameOver();
        }

        void _FireEvent_OnGameStart()
        {
            if (OnGameStart != null)
            {
                OnGameStart();
            }
        }
        void _FireEvent_OnGameOver()
        {
            if (OnGameOver != null)
            {
                OnGameOver();
            }
        }
    }
}
