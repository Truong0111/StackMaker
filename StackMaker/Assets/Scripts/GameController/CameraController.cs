using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private void Update()
    {
        this.transform.localPosition = _playerTransform.localPosition + new Vector3(0,10.76f,-10);
    }
}
