using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private GameObject target;

    [SerializeField] private Vector3 offset; //4.5
    [SerializeField] private bool useOffsetValues;

    private void Awake()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position - offset;
    }
}
