
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

    [SerializeField] private GameObject leftLeg;
    [SerializeField] private GameObject rightLeg;
    [SerializeField] private float legSpeed;

    private bool canKick;

    private float kickableDotProduct;

    private bool leftFootDown = false;
    private bool rightFootDown = false;



    override protected void Start()
    {
        base.Start();
        kickableDotProduct = Mathf.Abs(Mathf.Cos(kickableAngle));
    }

    private void FixedUpdate()
    {
        Vector2 mouseVector = mouse.transform.position - rollingRigidbody.transform.position;
        canKick = (Vector2.Angle(-rollingRigidbody.transform.up, mouseVector) < kickableAngle / 2);
        float targetAngle;
        float currentAngle = leftLeg.transform.localEulerAngles.z;
        if (canKick)
        {
            targetAngle = Vector2.SignedAngle(-rollingRigidbody.transform.up, mouseVector);
        }
        else
        {
            targetAngle = 0;
        }
        float angle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * legSpeed);
        Debug.Log(angle);
        leftLeg.transform.localEulerAngles = new Vector3(0, 0, angle);
        rightLeg.transform.localEulerAngles = leftLeg.transform.localEulerAngles;
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
        Vector2 mouseVectorToHips = mouse.transform.position - forcePoint;
        Vector2 force;
        if (canKick)
        {
            force = CalculateKickForce(forcePoint, mouseVectorToHips);
            rollingRigidbody.AddForceAtPosition(force, forcePoint, ForceMode2D.Impulse);
        }
        else
        {
            StartCoroutine(Brake(forcePoint, mouseVectorToHips));
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICollidable collidable = collision.collider.gameObject.GetComponent<ICollidable>();
        if (collidable != null)
        {
            collidable.Collide();
        }
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
