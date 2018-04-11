using UnityEngine;

namespace RollingBall
{
    [RequireComponent(typeof(CubeResetter))]
    public class CubeController : MonoBehaviour
    {
        [SerializeField]
        Vector3 rotateAxis;

        [SerializeField]
        float rotateForce;


        public static int TotalCube;


        void OnEnable()
        {
            TotalCube += 1;
        }

        void OnDisable()
        {
            TotalCube -= 1;
            if (TotalCube <= 0) {
                GameController.GameOver();
            }
        }

        void Update()
        {
            transform.Rotate((rotateAxis * rotateForce) * Time.deltaTime);
        }
    }
}
