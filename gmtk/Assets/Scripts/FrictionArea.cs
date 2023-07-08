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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("we are enforcing friction of value " + friction);

        IRolling rollingObject = other.GetComponent<IRolling>();
        if (rollingObject != null)
        {
            rollingObject.FrictionAreaEntered(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IRolling rollingObject = other.GetComponent<IRolling>();
        if (rollingObject != null)
        {
            rollingObject.FrictionAreaExited(this);
        }
    }
}
