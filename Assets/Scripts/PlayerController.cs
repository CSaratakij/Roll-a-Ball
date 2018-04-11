using UnityEngine;

namespace RollingBall
{
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


        public int Score {  get { return score; } }
        public bool IsControlable {  get { return IsControlable; } }


        int itemCount;
        int score;


        Collider[] hits;
        Rigidbody rigid;
        Vector3 inputVector;


        void Awake()
        {
            hits = new Collider[1];
            rigid = GetComponent<Rigidbody>();

            _Subscribe_Event();
        }

        void OnDisable()
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

        void _Subscribe_Event()
        {

        }

        void _Unsubscribe_Event()
        {

        }

        void _InputHandler()
        {
            if (!isControlable) { return; }

            inputVector.x = Input.GetAxisRaw("Horizontal");
            inputVector.z = Input.GetAxisRaw("Vertical");

            if (inputVector.magnitude > 1)
            {
                inputVector = inputVector.normalized;
            }
        }

        void _DetectCube_Handler()
        {
            if (_IsDetectCube())
            {
                if (!hits[0].gameObject.activeSelf) { return; }
                score += 100;
                hits[0].gameObject.SetActive(false);
            }
        }

        bool _IsDetectCube()
        {
            if (itemCount <= 0) { return false; }
            return (hits[0].transform.tag == "Cube");
        }
    }
}
