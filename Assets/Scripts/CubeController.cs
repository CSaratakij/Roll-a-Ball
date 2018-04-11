using UnityEngine;

namespace RollingBall
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField]
        Vector3 rotateAxis;

        [SerializeField]
        float rotateForce;


        void Update()
        {
            transform.Rotate(rotateAxis * rotateForce * Time.deltaTime);
        }
    }
}
