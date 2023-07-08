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
    public GameObject leftBrake;

    [SerializeField]
    public GameObject rightBrake;

    [SerializeField]
    public float forceMultiplier;

    [SerializeField]
    public float brakeMultiplier;

    [SerializeField] private float torqueMultiplier;

    [SerializeField] private float kickableAngle;

    [SerializeField]
    public GameObject mouse;

    private float kickableDotProduct;

    private bool leftFootDown = false;
    private bool rightFootDown = false;



    override protected void Start()
    {
        base.Start();
        kickableDotProduct = Mathf.Abs(Mathf.Cos(kickableAngle));
    }

    public void leftFoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            leftFootDown = true;
            AddForce(leftPoint.transform.position);
        }
        if (context.canceled)
        {
            leftFootDown = false;
        }
    }

    public void rightFoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            leftFootDown = true;
            AddForce(rightPoint.transform.position);
        }
        if (context.canceled)
        {
            leftFootDown = false;
        }
    }

    public void EngageBrake(InputAction.CallbackContext context)
    {
   
    }

    private void AddForce(Vector3 forcePoint)
    {
        Vector2 mouseVector = mouse.transform.position - forcePoint;
        Vector2 force;
        if (Vector2.Angle(-rollingRigidbody.transform.up, mouseVector) < kickableAngle / 2)
        {
            force = CalculateKickForce(forcePoint, mouseVector);
            rollingRigidbody.AddForceAtPosition(force, forcePoint, ForceMode2D.Impulse);
        }
        else
        {
            StartCoroutine(Brake(forcePoint, mouseVector));
        }
    }

    private Vector2 CalculateKickForce(Vector3 kickPoint, Vector2 mouseVector)
    {
        return mouseVector.normalized * -forceMultiplier;
    }

    private Vector2 CalculateBrakeForce(Vector3 brakePoint, Vector2 mouseVector)
    {
        float amount = Mathf.Min(brakeMultiplier, Vector2.Dot(rollingRigidbody.transform.up, rollingRigidbody.GetRelativePointVelocity(brakePoint)));
        return amount * -rollingRigidbody.transform.up;
    }

    private IEnumerator Brake(Vector3 brakePoint, Vector2 mouseVector)
    {
        /*
        while (leftFootDown || rightFootDown)
        {
            if (leftFootDown)
            {
                Vector2 force = CalculateBrakeForce(leftBrake.transform.position, mouseVector);
                rollingRigidbody.AddForceAtPosition(force, leftBrake.transform.position, ForceMode2D.Force);
            }
            if (rightFootDown)
            {
                Vector2 force = CalculateBrakeForce(rightBrake.transform.position, mouseVector);
                rollingRigidbody.AddForceAtPosition(force, rightBrake.transform.position, ForceMode2D.Force);
            }
            yield return new WaitForFixedUpdate();
        }
        */
        yield return null;
    }

}
