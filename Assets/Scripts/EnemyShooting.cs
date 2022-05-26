using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Shooting
{
    private float _timer;
    private float _nextShotTime;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_currentBullet.isActive == false)
        {
            if (_timer > _nextShotTime)
            {
                _timer = 0;
                _nextShotTime = Random.Range(1f, 3f);
                _currentBullet.Shot(_spawn.position, _spawn.rotation);
            }
        }
    }
}
