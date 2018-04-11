using UnityEngine;
using UnityEngine.UI;

namespace RollingBall.UI
{
    public class GameMenuController : MonoBehaviour
    {
        [SerializeField]
        RectTransform[] panelViews;


        public enum View
        {
            MainMenu,
            InGameUI,
            GameOver
        }


        void Awake()
        {
            _Subscribe_Event();
        }

        void Start()
        {
            ShowOnly(View.MainMenu);
        }

        void OnDestroy()
        {
            _Unsubscribe_Event();
        }

        void _Subscribe_Event()
        {
            GameController.OnGameStart += _OnGameStart;
            GameController.OnGameOver += _OnGameOver;
        }

        void _Unsubscribe_Event()
        {
            GameController.OnGameStart -= _OnGameStart;
            GameController.OnGameOver -= _OnGameOver;
        }

        void _OnGameStart()
        {
            ShowOnly(View.InGameUI);
        }

        void _OnGameOver()
        {
            ShowOnly(View.GameOver);
        }

        void _Show(View view)
        {
            panelViews[(int)view].gameObject.SetActive(true);
        }

        void _HideAllView()
        {
            foreach (var obj in panelViews) {
                obj.gameObject.SetActive(false);
            }
        }

        public void ShowOnly(View view)
        {
            _HideAllView();
            _Show(view);
        }
    }
}
