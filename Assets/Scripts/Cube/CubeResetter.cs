using UnityEngine;

namespace RollingBall
{
    public class CubeResetter : MonoBehaviour
    {
        void Awake()
        {
            _Subscribe_Event();
        }

        void OnDestroy()
        {
            _Unsubscribe_Event();
        }

        void _Subscribe_Event()
        {
            GameController.OnGameRestart += _OnGameRestart;
        }

        void _Unsubscribe_Event()
        {
            GameController.OnGameRestart -= _OnGameRestart;
        }

        void _OnGameRestart()
        {
            _Reset();
        }

        void _Reset()
        {
            gameObject.SetActive(true);
        }
    }
}
