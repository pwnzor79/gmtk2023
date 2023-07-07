using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionArea : MonoBehaviour
{

    [SerializeField]
    public float friction;

    [SerializeField]
    public float angularFriction;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("we are enforcing friction of value " + friction);

        //gameManager.playerController.playerRigidbody.drag = friction;
        //gameManager.playerController.playerRigidbody.angularDrag = angularFriction;

        gameManager.FrictionAreaEntered(this);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameManager.FrictionAreaExited(this);
    }

    public float getFriction()
    {
        return friction;
    }
}
