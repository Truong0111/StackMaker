using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private readonly Vector3 _offset = new Vector3(0, 15, -15);
    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        var targetPosition = playerTransform.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, 0.3f);
    }
    
}
