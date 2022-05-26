using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Tank
{
    [SerializeField] private GameObject _loseWindow;

    void Update()
    {
        OperateInput();
        if (_isMoving)
        {
            Vector3 nextPosition = transform.position + transform.up * _speed * Time.deltaTime;
            if (CheckPosition(nextPosition) == true)
            {
                transform.position = nextPosition;
            }
        }
    }
    void OperateInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetDirection(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetDirection(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetDirection(-Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetDirection(Vector3.left);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W))
            {
                SetDirection(Vector3.up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                SetDirection(Vector3.down);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                SetDirection(-Vector3.left);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                SetDirection(Vector3.left);
            }
            else
            {
                _isMoving = false;
            }
        }
    }
    protected override void Die()
    {
        base.Die();
        _loseWindow.SetActive(true);
    }
}
