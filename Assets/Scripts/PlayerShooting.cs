using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Shooting
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_currentBullet.isActive == false)
            {
                _currentBullet.Shot(_spawn.position, _spawn.rotation);
            }
        }   
    }
}
