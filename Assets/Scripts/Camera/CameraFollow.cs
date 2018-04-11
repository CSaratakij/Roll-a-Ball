﻿using UnityEngine;

namespace RollingBall
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        Transform target;


        Vector3 offset;


        void Start()
        {
            offset = transform.position - target.position;
        }

        void LateUpdate()
        {
            transform.position = (target.position + offset);
        }
    }
}
