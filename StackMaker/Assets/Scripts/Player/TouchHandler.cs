using System;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    private int TOUCH_HOLD = 111;

    public static Action<Direction> OnSwipt;
    public Direction Direction { get { return direction; } } 
    private Direction direction = Direction.none;
    private Direction lastdirection = Direction.none;

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
        if (_touchDis.magnitude > TOUCH_HOLD)
        {
            float x = _touchDis.x;
            float y = _touchDis.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x < 0)
                {
                    UpdateDirection(Direction.swiptLeft);
                }
                else
                {
                    UpdateDirection(Direction.swiptRight);
                }
            }
            else  
            {
                if (y < 0)
                {
                    UpdateDirection(Direction.swiptBackward);
                }
                else
                {
                    UpdateDirection(Direction.swiptForward);
                }
            }
        }
    }
    private void UpdateDirection(Direction direct)
    {
        if(direction != direct)
        {
            lastdirection = direction;
            direction = direct;
            OnSwipt(direction);
        }
    }
}

public enum Direction
{
    swiptLeft,
    swiptRight,
    swiptForward,
    swiptBackward,
    none
}
