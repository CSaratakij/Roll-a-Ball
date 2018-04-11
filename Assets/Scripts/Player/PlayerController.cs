using UnityEngine;

namespace RollingBall
{
    [RequireComponent(typeof(PlayerResetter))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        bool isControlable;

        [SerializeField]
        float moveForce;

        [SerializeField]
        float radius;

        [SerializeField]
        LayerMask itemMask;


        public bool IsControlable {  get { return isControlable; } }


        int itemCount;


        Collider[] hits;
        Rigidbody rigid;
        Vector3 inputVector;


        void Awake()
        {
            _Initialize();
            _Subscribe_Event();
        }

        void OnDestroy()
        {
            _Unsubscribe_Event();
        }

        void Update()
        {
            _InputHandler();
            _DetectCube_Handler();
        }

        void FixedUpdate()
        {
            rigid.AddForce((inputVector * moveForce) * Time.deltaTime, ForceMode.Force);
            itemCount = Physics.OverlapSphereNonAlloc(rigid.position, radius, hits, itemMask);
        }

        void _Initialize()
        {
            hits = new Collider[1];
            rigid = GetComponent<Rigidbody>();
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
            isControlable = true;
        }

        void _OnGameOver()
        {
            isControlable = false;
        }

        void _InputHandler()
        {
            if (!isControlable) {
                inputVector = Vector3.zero;
                return;
            }

            inputVector.x = Input.GetAxisRaw("Horizontal");
            inputVector.z = Input.GetAxisRaw("Vertical");

            if (inputVector.magnitude > 1) {
                inputVector = inputVector.normalized;
            }
        }

        void _DetectCube_Handler()
        {
            if (!_IsDetectCube()) { return; }
            if (!hits[0].gameObject.activeSelf) { return; }

            Global.AddScore(100);
            hits[0].gameObject.SetActive(false);
        }

        bool _IsDetectCube()
        {
            if (itemCount <= 0) { return false; }
            return (hits[0].transform.tag == "Cube");
        }
    }
}
