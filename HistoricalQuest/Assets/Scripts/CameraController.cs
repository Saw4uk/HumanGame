using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
        [SerializeField] private Transform cameraTarget;
        private Vector3 pos;
        private void Awake()
        {

        }
        void Start()
        {

        }


        void Update()
        {
            pos = cameraTarget.position;
            pos.z = -15f;
            pos.y = cameraTarget.position.y + 5.3f;
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime + 0.05f);
        }
    }