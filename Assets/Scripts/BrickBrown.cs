using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBrown : Brick
{
    public override void TakeDamage()
    {
        base.TakeDamage();
        Destroy(gameObject);
    }
}
