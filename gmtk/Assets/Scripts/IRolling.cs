using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRolling : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rollingRigidbody;

    private GameManager gameManager;
    private FrictionArea currentArea;

    virtual protected void Start()
    {
        gameManager = GameManager.instance;
        Debug.Log(gameManager);
    }

    public void FrictionAreaEntered(FrictionArea frictionArea)
    {
        currentArea = frictionArea;
        rollingRigidbody.drag = frictionArea.friction;
        rollingRigidbody.angularDrag = frictionArea.angularFriction;
    }

    public void FrictionAreaExited(FrictionArea frictionArea)
    {
        if (frictionArea = currentArea)
        {
            rollingRigidbody.drag = gameManager.defaultDrag;
            rollingRigidbody.angularDrag = gameManager.defaultAngularDrag;
        }
    }
}
