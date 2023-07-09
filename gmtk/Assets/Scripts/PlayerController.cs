
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
    public GameObject leftSpin;

    [SerializeField]
    public GameObject rightSpin;

    [SerializeField] private GameObject leftShin;
    [SerializeField] private GameObject leftShinL;
    [SerializeField] private GameObject leftShinR;
    [SerializeField] private GameObject rightShin;
    [SerializeField] private GameObject rightShinL;
    [SerializeField] private GameObject rightShinR;

    [SerializeField]
    public float forceMultiplier;

    [SerializeField] private float spinMultiplier;

    [SerializeField]
    public float collideVelocity;



    [SerializeField] private float torqueMultiplier;

    [SerializeField] private float kickableAngle;
    [SerializeField] private float spinStartAngle;
    [SerializeField] private float maxCursorAngle;


    [SerializeField]
    public GameObject mouse;

    [SerializeField] private GameObject leftLeg;
    [SerializeField] private GameObject rightLeg;
    [SerializeField] private float legSpeed;
    [SerializeField] private float legAngle;

    private bool inKickRange;
    private bool inClickRange;
    private bool inSpinRange;
    private bool inLegRange;
    private bool leftSide;

    private bool leftFootDown = false;
    private bool rightFootDown = false;


    protected override void Start()
    {
        base.Start();
        leftShin.SetActive(false);
        leftShinL.SetActive(false);
        leftShinR.SetActive(false);

        rightShin.SetActive(false);
        rightShinL.SetActive(false);
        rightShinR.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector2 mouseVector = mouse.transform.position - rollingRigidbody.transform.position;
        float mouseAngle = Vector2.Angle(-rollingRigidbody.transform.up, mouseVector);
        inKickRange =  mouseAngle < (kickableAngle / 2);
        inClickRange = mouseAngle < (maxCursorAngle / 2);
        inSpinRange = mouseAngle > (spinStartAngle / 2);
        inLegRange = mouseAngle < (legAngle / 2);
        leftSide = Vector2.SignedAngle(-rollingRigidbody.transform.up, mouseVector) > 0;

        float targetAngle;
        float currentAngle = leftLeg.transform.localEulerAngles.z;
        if (inClickRange)
        {
            targetAngle = Vector2.SignedAngle(-rollingRigidbody.transform.up, mouseVector);
        }
        else
        {
            targetAngle = 0;
        }
        float angle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * legSpeed);
        angle += 180;
        angle %= 360;
        angle = Mathf.Clamp(angle, 180 - (legAngle / 2), 180 + (legAngle / 2));
        angle -= 180;

        leftLeg.transform.localEulerAngles = new Vector3(0, 0, angle);
        rightLeg.transform.localEulerAngles = leftLeg.transform.localEulerAngles;
    }

    public void leftFoot(InputAction.CallbackContext context)
    {
        if (context.started && inClickRange)
        {
            Vector3 forcePoint;
            if (inSpinRange)
            {
                forcePoint = leftSpin.transform.position;
                if (leftSide)
                {
                    leftShinL.SetActive(true);
                }
                else
                {
                    leftShinR.SetActive(true);
                }
                int direction = leftSide ? -1 : 1;
                rollingRigidbody.AddForceAtPosition(direction * this.transform.right * spinMultiplier, forcePoint, ForceMode2D.Impulse);
            }
            else
            {
                leftShin.SetActive(true);
                forcePoint = leftPoint.transform.position;
                AddForce(forcePoint);
            }
        }
        if (context.canceled)
        {
            leftShin.SetActive(false);
            leftShinL.SetActive(false);
            leftShinR.SetActive(false);
        }
    }

    public void rightFoot(InputAction.CallbackContext context)
    {
        if (context.started && inClickRange)
        {
            Vector3 forcePoint;
            if (inSpinRange)
            {
                forcePoint = rightSpin.transform.position;
                if(leftSide)
                {
                    rightShinL.SetActive(true);
                }
                else
                {
                    rightShinR.SetActive(true);
                }
                int direction = leftSide ? -1 : 1;
                rollingRigidbody.AddForceAtPosition(direction * this.transform.right * spinMultiplier, forcePoint, ForceMode2D.Impulse);
            }
            else
            {
                forcePoint = rightPoint.transform.position;
                rightShin.SetActive(true);
                AddForce(forcePoint);
            }
            
        }
        if (context.canceled)
        {
            rightShin.SetActive(false);
            rightShinL.SetActive(false);
            rightShinR.SetActive(false);
        }
    }

    private void AddForce(Vector3 forcePoint)
    {
        Vector2 mouseVectorToHips = mouse.transform.position - forcePoint;
        Vector2 force = CalculateKickForce(forcePoint, mouseVectorToHips);
        rollingRigidbody.AddForceAtPosition(force, forcePoint, ForceMode2D.Impulse);
    }

    private Vector2 CalculateKickForce(Vector3 kickPoint, Vector2 mouseVector)
    {
        if (inKickRange)
        {
            return mouseVector.normalized * -forceMultiplier;
        }
        else
        {
            return RadianToVector2((kickableAngle / 2) * Mathf.Deg2Rad) * rollingRigidbody.transform.up * -forceMultiplier;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICollidable collidable = collision.collider.gameObject.GetComponent<ICollidable>();
        if (collidable != null)
        {
            if (rollingRigidbody.velocity.magnitude >= collideVelocity)
            {
                gameManager.damage += collidable.Collide();
            }
        }
    }

    //Bunny83 on unity forms
    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
}
