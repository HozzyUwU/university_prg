using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform target;

    [SerializeField] private Vector3 offset; //4.5
    [SerializeField] private bool useOffsetValues;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position - offset;
    }
}
