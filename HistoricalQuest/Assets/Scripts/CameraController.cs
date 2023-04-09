using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
        [SerializeField] private Transform cameratarget;
        private Vector3 pos;
        private void Awake()
        {

        }
        void Start()
        {

        }


        void Update()
        {
            pos = cameratarget.position;
            pos.z = -15f;
            pos.y = cameratarget.position.y + 4f;
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime + 0.05f);
        }
    }