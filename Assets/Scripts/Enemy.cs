using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tank
{
    private float _timer;
    private float _timeToChangeDirection;
    private EnemyCreator _enemyCreator;

    public void Initialize(EnemyCreator enemyCreator)
    {
        _enemyCreator = enemyCreator;
    }
    void Start()
    {
        _isMoving = true;
    }

    void Update()
    {
        if (_isMoving)
        {
            _timer += Time.deltaTime;
            if (_timer > _timeToChangeDirection)
            {
                SetRandomDirection();
                _timeToChangeDirection = Random.Range(2f, 5f);
            }

            Vector3 nextPosition = transform.position + transform.up * _speed * Time.deltaTime;
            if (CheckPosition(nextPosition) == true)
            {
                transform.position = nextPosition;
            }
            else
            {
                _isMoving = false;
                StartCoroutine(SetRandomDirectionAfterTime());
            }
        }
    }

    IEnumerator SetRandomDirectionAfterTime()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1.5f));
        SetRandomDirection();
    }

    void SetRandomDirection()
    {
        int directionIndex = Random.Range(0, 4);

        if (directionIndex == 0)
        {
            SetDirection(Vector3.up);
        }
        else if (directionIndex == 1)
        {
            SetDirection(Vector3.down);
        }
        else if (directionIndex == 2)
        {
            SetDirection(-Vector3.left);
        }
        else
        {
            SetDirection(Vector3.left);
        }
        _isMoving = true;
        _timer = 0f;
    }

    protected override void Die()
    {
        base.Die();
        _enemyCreator.RemoveEnemy(this);
    }
}
