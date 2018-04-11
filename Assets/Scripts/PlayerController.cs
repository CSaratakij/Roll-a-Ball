using UnityEngine;

namespace RollingBall
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        float moveForce;


        Rigidbody rigid;
        Vector3 inputVector;


        void Awake()
        {
            rigid = GetComponent<Rigidbody>();
        }

        void Update()
        {
            _InputHandler();
        }

        void FixedUpdate()
        {
            rigid.AddForce((inputVector * moveForce) * Time.deltaTime, ForceMode.Force);
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
    }
}
