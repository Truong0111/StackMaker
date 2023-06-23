using System;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    private const int TouchHold = 111;

    public static Action<Direction> OnSwipt;
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
            _touchDis = Vector2.zero;
        }
        _touchDis = Vector2.zero;

        if( _isDragging)
        {
            if(Input.GetMouseButton(0))
            {
                _touchDis = (Vector2)Input.mousePosition - _touchPos;
            }
        }

        if (!(_touchDis.magnitude > TouchHold)) return;
        var x = _touchDis.x;
        var y = _touchDis.y;
        if(Mathf.Abs(x) > Mathf.Abs(y))
        {
            UpdateDirection(x < 0 ? Direction.SwiptLeft : Direction.SwiptRight);
        }
        else
        {
            UpdateDirection(y < 0 ? Direction.SwiptBackward : Direction.SwiptForward);
        }
    }
    private void UpdateDirection(Direction direct)
    {
        if (OnSwipt != null && _direction != direct)
        {
            _direction = direct;
            OnSwipt(_direction);
        }
    }
}

public enum Direction
{
    SwiptLeft,
    SwiptRight,
    SwiptForward,
    SwiptBackward,
    None
}