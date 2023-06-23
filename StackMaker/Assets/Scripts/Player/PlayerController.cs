using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _canMove;
    [SerializeField] private float speed = 15f;
    private Transform _playerTranform;
    private Vector3 _targetPos;

    
    private void Awake()
    {
        InitAwake();
    }

    private void Update()
    {
        InitUpdate();
    }

    private void InitAwake()
    {
        _playerTranform = GetComponent<Transform>();
        TouchHandler.OnSwipe += FindTarget;
    }

    private void InitUpdate()
    {
        if (PlayerStack.Ins.IsWin) _canMove = false;
        if (!_canMove) return;
        if (!_playerTranform || !_playerTranform.gameObject.activeSelf) return;
        if ((_playerTranform.position - _targetPos).sqrMagnitude > 0.0001f)
        {
            _playerTranform.position = Vector3.MoveTowards(_playerTranform.position, _targetPos, speed * Time.deltaTime);
        }
        else
        {
            _canMove = false;
        }
    }
    
    private const float MoveDistance = 2f;

    private void FindTarget(Direction direct)
    {
        if (!_playerTranform || !_playerTranform.gameObject.activeSelf) return;
        switch (direct)
        {
            case Direction.SwipeLeft:
                Raycasting(_playerTranform.position, Vector3.left * MoveDistance);
                break;
            case Direction.SwipeRight:
                Raycasting(_playerTranform.position, Vector3.right * MoveDistance);
                break;
            case Direction.SwipeForward:
                Raycasting(_playerTranform.position, Vector3.forward * MoveDistance);
                break;
            case Direction.SwipeBackward:
                Raycasting(_playerTranform.position, Vector3.back * MoveDistance);
                break;
            case Direction.None:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direct), direct, null);
        }
        _canMove = true;
    }

    private bool Raycasting(Vector3 startRay, Vector3 direct)
    {
        if (!Physics.Raycast(startRay, direct, out var hit, 1.5f * MoveDistance)) 
        {
            return false;
        }
        if (hit.transform.CompareTag(Const.ENABLE_STACK_TAG) ||
            hit.transform.CompareTag(Const.UNENABLE_STACK_TAG) ||
            hit.transform.CompareTag(Const.WALKABLE_STACK_TAG) ||
            hit.transform.CompareTag(Const.END_POS_TAG))
        {
            _targetPos = hit.transform.position;
            startRay += direct;
            return Raycasting(startRay, direct);
        }

        return true;
    }
}
