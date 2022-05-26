using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] protected Transform _spawn;
    protected Bullet _currentBullet;

    private void Start()
    {
        _currentBullet = Instantiate(_bulletPrefab, _spawn.position, _spawn.rotation);
        _currentBullet.Hide();
    }
}
