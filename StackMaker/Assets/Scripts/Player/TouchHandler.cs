using System;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    private const int TouchHoldThreshold  = 111;

    public static Action<Direction> OnSwipe;
    private Direction _direction = Direction.None;

    private Vector2 _touchPos, _touchDis;
    private bool _isDragging = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            _touchPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
            _touchPos = Vector2.zero;
        }
        _touchDis = Vector2.zero;

        if( _isDragging)
        {
            if(Input.GetMouseButton(0))
            {
                _touchDis = (Vector2)Input.mousePosition - _touchPos;
            }
        }

        if (!(_touchDis.magnitude > TouchHoldThreshold )) return;
        var x = _touchDis.x;
        var y = _touchDis.y;
        if(Mathf.Abs(x) > Mathf.Abs(y))
        {
            UpdateDirection(x < 0 ? Direction.SwipeLeft : Direction.SwipeRight);
        }
        else
        {
            UpdateDirection(y < 0 ? Direction.SwipeBackward : Direction.SwipeForward);
        }
    }
    private void UpdateDirection(Direction direct)
    {
        if (OnSwipe != null && _direction != direct)
        {
            _direction = direct;
            OnSwipe(_direction);
        }
    }
}

public enum Direction
{
    SwipeLeft,
    SwipeRight,
    SwipeForward,
    SwipeBackward,
    None
}