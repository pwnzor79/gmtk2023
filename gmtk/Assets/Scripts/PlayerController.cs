using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public GameObject leftPoint;

    [SerializeField]
    public GameObject rightPoint;

    [SerializeField]
    public Rigidbody2D playerRigidbody;

    [SerializeField]
    public float forceMultiplier;

    [SerializeField]
    public GameObject mouse;

    public Vector2 leftKickForce;
    public Vector2 rightKickForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {

    }

    /*
    private void OnCollisionEnter2D(Collider2D collision)
    {
        FrictionArea frictionArea = collision.GetComponent<FrictionArea>();

        if (frictionArea != null)
        {
            Debug.Log("we are experiencing friction of value " + frictionArea.friction);
            playerRigidbody.drag = frictionArea.friction;
        }
    }
    */

    public void leftKick(InputAction.CallbackContext context)
    {
        if(!context.started)
        {
            return;
        }
        //Debug.Log("left kick");
        leftKickForce = (mouse.transform.position - this.transform.position).normalized * -forceMultiplier;
        playerRigidbody.AddForceAtPosition(leftKickForce, leftPoint.transform.position, ForceMode2D.Impulse); //get vector between player and mouse (mouse-player) normalize, multiply by force value
    }

    public void rightKick(InputAction.CallbackContext context)
    {
        //Debug.Log("right kick");
        rightKickForce = (mouse.transform.position - this.transform.position).normalized * -forceMultiplier;
        playerRigidbody.AddForceAtPosition(rightKickForce, rightPoint.transform.position, ForceMode2D.Impulse); //get vector between player and mouse (mouse-player) normalize, multiply by force value
    }

}
