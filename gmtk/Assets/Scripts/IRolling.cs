using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRolling : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rollingRigidbody;

    [SerializeField]
    public float collideVelocity;

    protected GameManager gameManager;
    private FrictionArea currentArea;

    virtual protected void Start()
    {
        gameManager = GameManager.instance;
        ResetFriction();
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
            ResetFriction();
        }
    }

    private void ResetFriction()
    {
        rollingRigidbody.drag = gameManager.defaultDrag;
        rollingRigidbody.angularDrag = gameManager.defaultAngularDrag;
    }

    public void Boioioioing(Vector2 normal)
    {
        rollingRigidbody.velocity = Vector2.Reflect(rollingRigidbody.velocity, normal);
        rollingRigidbody.transform.up = -rollingRigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICollidable collidable = collision.collider.gameObject.GetComponent<ICollidable>();
        if (collidable != null)
        {
            if (rollingRigidbody.velocity.magnitude >= collideVelocity)
            {
                int damage = collidable.Collide(this, collision.GetContact(0).normal);
                if (this.gameObject.GetComponent<PlayerController>())
                {
                    gameManager.damage += damage;
                }
            }
        }
    }
}
