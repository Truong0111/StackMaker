using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchHanler : MonoBehaviour
{

    //private Direction direction = Direction.None;
    //public Direction Direction { get { return direction; } }

    //private Vector2 _touchStart;
    //private Vector2 _touchEnd;

    //private bool _isDragging;
    //private float _touchX, _touchY;

    string message;
    private void Start()
    {
        
    }
    private void Update()
    {
        TouchDrag();
    }

    private void TouchDrag()
    {
        
    }
}
public enum Direction
{
    Forward,
    Back,
    Left,
    Right,
    None
}
