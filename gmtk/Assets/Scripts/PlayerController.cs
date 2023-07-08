using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : IRolling
{
    [SerializeField]
    public GameObject leftPoint;

    [SerializeField]
    public GameObject rightPoint;

    [SerializeField]
    public float forceMultiplier;

    [SerializeField]
    public GameObject mouse;

    public Vector2 leftKickForce;
    public Vector2 rightKickForce;


    public void leftKick(InputAction.CallbackContext context)
    {
        if(!context.started)
        {
            return;
        }
        //Debug.Log("left kick");
        leftKickForce = (mouse.transform.position - this.transform.position).normalized * -forceMultiplier;
        rollingRigidbody.AddForceAtPosition(leftKickForce, leftPoint.transform.position, ForceMode2D.Impulse); //get vector between player and mouse (mouse-player) normalize, multiply by force value
    }

    public void rightKick(InputAction.CallbackContext context)
    {
        //Debug.Log("right kick");
        rightKickForce = (mouse.transform.position - this.transform.position).normalized * -forceMultiplier;
        rollingRigidbody.AddForceAtPosition(rightKickForce, rightPoint.transform.position, ForceMode2D.Impulse); //get vector between player and mouse (mouse-player) normalize, multiply by force value
    }

}
