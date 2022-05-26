using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] private Collider _collider;
    [SerializeField] private int _health;

    private Vector3 _currentDirection;
    protected bool _isMoving;

    protected void SetDirection(Vector3 direction)
    {
        _isMoving = true;

        if (direction != _currentDirection)
        {
            float x = Mathf.Round(transform.position.x / 0.5f) * 0.5f;
            float y = Mathf.Round(transform.position.y / 0.5f) * 0.5f;

            transform.position = new Vector3(x, y, 0);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }

    protected bool CheckPosition(Vector3 position)
    {
        Collider[] allColliders = Physics.OverlapBox(position, Vector3.one * 0.98f / 2f, transform.rotation);

        for (int i = 0; i < allColliders.Length; i++)
        {
            if (allColliders[i] != _collider)
            {
                Vector3 toCollider = allColliders[i].transform.position - transform.position;
                if (Vector3.Angle(toCollider, transform.up) < 50f)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void TakeDamage()
    {
        _health -= 1;
        if (_health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
