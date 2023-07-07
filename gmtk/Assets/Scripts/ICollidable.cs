using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICollidable : MonoBehaviour
{
    [SerializeField] float timePenalty = 0;

    public float GetTimePenalty()
    {
        return timePenalty;
    }

    public void Collide()
    {
        // Do nothing
    }
}
