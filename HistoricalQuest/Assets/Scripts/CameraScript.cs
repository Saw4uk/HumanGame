using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform cameratarget;
    private Vector3 pos;

    void Update()
    {
        pos = cameratarget.position;
        pos.z = -10f;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime + 0.05f);
    }
}

