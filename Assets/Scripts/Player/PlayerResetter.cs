using UnityEngine;

namespace RollingBall
{
    public class PlayerResetter : MonoBehaviour
    {
        Vector3 origin;
        Rigidbody rigid;


        void Awake()
        {
            _Initialize();
            _Subscribe_Event();
        }

        void OnDestroy()
        {
            _Unsubscribe_Event();
        }

        void _Initialize()
        {
            origin = transform.position;
            rigid = GetComponent<Rigidbody>();
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
            transform.position = origin;
            rigid.velocity = Vector3.zero;
            Global.Reset();
        }
    }
}
