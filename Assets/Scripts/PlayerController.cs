using UnityEngine;

namespace RollingBall
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        float moveForce;

        [SerializeField]
        float radius;

        [SerializeField]
        LayerMask itemMask;


        public int Score {  get { return score; } }


        int itemCount;
        int score;


        Collider[] hit;
        Rigidbody rigid;
        Vector3 inputVector;


        void Awake()
        {
            hit = new Collider[1];
            rigid = GetComponent<Rigidbody>();
        }

        void Update()
        {
            _InputHandler();
            _DetectCube_Handler();
        }

        void FixedUpdate()
        {
            rigid.AddForce((inputVector * moveForce) * Time.deltaTime, ForceMode.Force);
            itemCount = Physics.OverlapSphereNonAlloc(transform.position, radius, hit);
        }

        void _InputHandler()
        {
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
                score += 100;
                hit[0].gameObject.SetActive(false);
            }
        }

        bool _IsDetectCube()
        {
            if (itemCount <= 0) { return false; }
            return (hit[0].transform.tag == "Cube");
        }
    }
}
