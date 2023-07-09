using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boioioioing : ICollidable
{
    public override int Collide(IRolling rolling, Vector2 collisionNormal)
    {
        rolling.Boioioioing(collisionNormal);
        return base.Collide(rolling, collisionNormal);
    }
}
