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

    public void leftKick(InputAction.CallbackContext context)
    {
        Debug.Log("left kick");
        leftKickForce = (mouse.transform.position - this.transform.position).normalized * forceMultiplier;
        playerRigidbody.AddForceAtPosition(leftKickForce, leftPoint.transform.position); //get vector between player and mouse (mouse-player) normalize, multiply by force value
    }

    public void rightKick(InputAction.CallbackContext context)
    {
        Debug.Log("right kick");
        rightKickForce = (mouse.transform.position - this.transform.position).normalized * forceMultiplier;
        playerRigidbody.AddForceAtPosition(rightKickForce, rightPoint.transform.position); //get vector between player and mouse (mouse-player) normalize, multiply by force value
    }

}
