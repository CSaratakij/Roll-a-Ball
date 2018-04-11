namespace RollingBall
{
    public class Global
    {
        public delegate void FuncScoreChanged(int value);
        public static event FuncScoreChanged OnScoreChanged;

        public static int Score { get { return _score; } }


        static int _score;


        static void _FireEvent_OnScoreChanged()
        {
            if (OnScoreChanged != null) {
                OnScoreChanged(Score);
            }
        }

        public static void AddScore(int value)
        {
            _score += value;
            _FireEvent_OnScoreChanged();
        }

        public static void Reset()
        {
            _score = 0;
            _FireEvent_OnScoreChanged();
        }
    }
}
