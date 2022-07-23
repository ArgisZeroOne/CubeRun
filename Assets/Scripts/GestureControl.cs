using System;
using System.Collections.Generic;
using UnityEngine;

public class GestureControl : MonoBehaviour
{

    [SerializeField]  private float _mouseDownPosX;
    [SerializeField] private float _mouseUpPosX;
    private float _mouseDownPosY;
    private float _mouseUpPosY;
    private bool _startGesture = false;
    [SerializeField]private int _horizontalSensitivity = 200;
    [SerializeField]private int _verticalSensitivity = 200;
    private PlayerMovement _player;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void Gesture()
    {
        float moveX = _mouseUpPosX - _mouseDownPosX;
        Debug.Log(Math.Abs(moveX)+moveX);
        float moveY = _mouseDownPosY - _mouseUpPosY;
        if (Math.Abs(moveX) > Math.Abs(moveY))
        {
            if (Math.Abs(moveX) > _horizontalSensitivity)
            {
                if (moveX > 0)
                {
                    _player.RightMove();
                }
                else 
                {
                    _player.LeftMove();
                }
            }
        }
        else if (Math.Abs(moveY) > Math.Abs(moveX))
        {
            if (Math.Abs(moveY) > _verticalSensitivity)
            {
                if (moveY < 0)
                {
                    _player.UpMove();
                }
                else if (moveY > 0)
                {
                    _player.DownMove();
                }

            }
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseDownPosX = Input.mousePosition.x;
            _mouseDownPosY = Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _mouseUpPosX = Input.mousePosition.x;
            _mouseUpPosY = Input.mousePosition.y;
            _startGesture = true;
        }
        if (_startGesture)
        {
            _startGesture = false;
            Gesture();
        }
    }
}
