using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    public static PlayerController Ins;
    private void Awake()
    {
        Ins = this;
    }
    #endregion
    public bool CanMove { get => _canMove; }

    private bool _canMove;
    [SerializeField] private float speed = 15f;
    private Transform _playerTranform;
    private Vector3 targetPos;


    private void Start()
    {
        _playerTranform = transform;
        TouchHandler.OnSwipt += FindTarget;
    }

    private void Update()
    {
        if (_canMove)
        {
            if ((_playerTranform.position - targetPos).sqrMagnitude > 0.0001f)
            {
                _playerTranform.position = Vector3.MoveTowards(_playerTranform.position, targetPos, speed * Time.deltaTime);
            }
            else
            {
                _canMove = false;
            }
        }
    }

    private void FindTarget(Direction direct)
    {
        switch (direct)
        {
            case Direction.swiptLeft:
                Raycasting(_playerTranform.position, Vector3.left * 2 );
                break;
            case Direction.swiptRight:
                Raycasting(_playerTranform.position, Vector3.right * 2);
                break;
            case Direction.swiptForward:
                Raycasting(_playerTranform.position, Vector3.forward * 2);
                break;
            case Direction.swiptBackward:
                Raycasting(_playerTranform.position, Vector3.back * 2);
                break;
        }
        _canMove = true;
    }
    private void Raycasting(Vector3 startRay, Vector3 direct)
    {
        RaycastHit hit;
        if(Physics.Raycast(startRay, direct, out hit, 2f))
        {
            Debug.Log("Hit " + hit.transform.name);
            if (hit.transform.CompareTag(Const.ENABLE_STACK_TAG) ||
                hit.transform.CompareTag(Const.UNENABLE_STACK_TAG) ||
                hit.transform.CompareTag(Const.WALKABLE_STACK_TAG))
            {
                targetPos = hit.transform.position;
                startRay += direct;
                Raycasting(startRay, direct);
            }
        }
    }
}
