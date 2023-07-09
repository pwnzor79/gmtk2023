using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICollidable : MonoBehaviour
{
    [SerializeField] SpriteRenderer collidableRenderer;
    [SerializeField] Sprite damagedSprite;
    [SerializeField] GameObject otherObject;
    [SerializeField] AudioSource hitSound;
    [SerializeField] int penalty = 0;

    virtual public int Collide(IRolling rolling, Vector2 collisionNormal)
    {
        if (damagedSprite != null)
        {
            collidableRenderer.sprite = damagedSprite;
        }
        if (hitSound != null)
        {
            Debug.Log("playing sound");
            hitSound.Play();
            hitSound = null;
        }
        if (otherObject != null)
        {
            //do destroy(this.gameobject, delayTime) instead of setActive, make sure the watercooler has its own sprite to disable it.
            Destroy(this.gameObject, 0.4f);
            Destroy(collidableRenderer);
            otherObject.SetActive(true);
            //this.gameObject.SetActive(false);
        }
        int returnValue = penalty;
        penalty = 0;
        return returnValue;
    }
}
