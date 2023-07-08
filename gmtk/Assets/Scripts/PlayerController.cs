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

    [SerializeField] private float torqueMultiplier;

    [SerializeField] private float kickableAngle;

    [SerializeField]
    public GameObject mouse;

    private float kickableDotProduct;

    override protected void Start()
    {
        base.Start();
        kickableDotProduct = Mathf.Abs(Mathf.Cos(kickableAngle));
    }



    public void leftKick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Kick(leftPoint.transform.position);
        }
    }

    public void rightKick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Kick(rightPoint.transform.position);
        }
    }

    private void Kick(Vector3 kickPoint)
    {
        Vector2 mouseVector = mouse.transform.position - kickPoint;
        float dot = Vector2.Dot(mouseVector.normalized, -rollingRigidbody.transform.up.normalized);
        //Debug.Log(dot + " " + kickableDotProduct);
        if (dot >= kickableDotProduct)
        {
            rollingRigidbody.angularVelocity = 0;

            Vector2 kickForce = mouseVector.normalized * -forceMultiplier;
            rollingRigidbody.AddForceAtPosition(kickForce, kickPoint, ForceMode2D.Impulse); //get vector between player and mouse (mouse-player) normalize, multiply by force value
        }
    }

}
