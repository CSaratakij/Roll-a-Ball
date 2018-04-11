namespace RollingBall
{
    public class GameController
    {
        public delegate void Func();

        public static event Func OnGameStart;
        public static event Func OnGameOver;
        public static event Func OnGameRestart;


        static bool isGameStart;


        static void _FireEvent_OnGameStart()
        {
            if (OnGameStart != null) {
                OnGameStart();
            }
        }
        static void _FireEvent_OnGameOver()
        {
            if (OnGameOver != null) {
                OnGameOver();
            }
        }

        static void _FireEvent_OnGameRestart()
        {
            if (OnGameRestart != null) {
                OnGameRestart();
            }
        }

        public static void GameStart()
        {
            isGameStart = true;
            _FireEvent_OnGameStart();
        }

        public static void GameOver()
        {
            if (!isGameStart) { return; }
            isGameStart = false;
            _FireEvent_OnGameOver();
        }

        public static void RestartGame()
        {
            _FireEvent_OnGameRestart();
            GameStart();
        }
    }
}
